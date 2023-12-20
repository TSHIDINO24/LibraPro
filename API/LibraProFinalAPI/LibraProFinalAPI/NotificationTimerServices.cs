using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LibraProFinalAPI.Model;

public class NotificationTimerService : IHostedService, IDisposable
{
    private readonly ILogger<NotificationTimerService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private Timer _timer;

    public NotificationTimerService(ILogger<NotificationTimerService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("NotificationTimerService is starting.");

        // Schedule the task to run daily 
        var now = DateTime.Now;
        var nextRunTime = new DateTime(now.Year, now.Month, now.Day, 22, 35, 0).AddDays(0);
        var delay = nextRunTime - now;

        _timer = new Timer(DoWork, null, delay, TimeSpan.FromHours(1));

        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        _logger.LogInformation("NotificationTimerService is doing work at: " + DateTime.Now);

        try
        {
            // Place your notification logic here
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LibraProFinalDataContext>();

                DateTime currentDate = DateTime.Today;

                // Find Books that are due in 2 days
                var checkDueDate = dbContext.Checkouts
                    .Where(d => EF.Functions.DateDiffDay(currentDate, d.BorrowReturnedDate) >= 2)
                    .ToList();

                foreach (var bookDue in checkDueDate)
                {
                    // Create a notification in the database
                    var createNotif = new Notification
                    {
                        NotificationDetails = $"Book: {bookDue.BookTitle} under this Borrow Code: {bookDue.BorrowCode} is due in 2 days on {bookDue.BorrowReturnedDate.ToShortDateString()}",
                        NotificationDate = DateTime.Now,
                        UserId = bookDue.UserId
                    };

                    dbContext.Notifications.Add(createNotif);
                }

                // Handle overdue books and fines
                var overdueBooks = dbContext.Checkouts.Where(d => d.BorrowReturnedDate > currentDate);

                foreach (var overdueBook in overdueBooks)
                {
                    var notificationTitle = "Fine";
                    var createNotif = new Notification
                    {
                        NotificationDate = currentDate,
                        NotificationDetails = $"Books under this Borrow Code: {overdueBook.BorrowCode} have passed the due date on {overdueBook.BorrowReturnedDate.ToShortDateString()}. Please return them.",
                        UserId = overdueBook.UserId
                    };
                    dbContext.Notifications.Add(createNotif);
                    
                }

                dbContext.SaveChanges();
            }

            _logger.LogInformation("NotificationTimerService completed its work at: " + DateTime.Now);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing notifications.");
        }
    }


    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("NotificationTimerService is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
