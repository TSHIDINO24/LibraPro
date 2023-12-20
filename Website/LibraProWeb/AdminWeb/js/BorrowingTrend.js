/////////////////////////////////////////////////////// BORROWING STATS CHART
document.addEventListener("DOMContentLoaded", async function() {
    // Function to fetch data from the API
    async function fetchData(apiEndpoint) {
        try {
            const response = await fetch(apiEndpoint);
            const data = await response.json();
            return data;
        } catch (error) {
            console.error('Error fetching data:',error);
            return null;
        }
    }

    // Function to count books based on status and date range
    function countBooksByStatusAndDate(booksData, status, startDate, endDate) {
        return booksData.filter(book => book.status === status && new Date(book.borrowDate) >= startDate && new Date(book.borrowDate) <= endDate).length;
    }

    // Get the current date
    const today = new Date();
    const thisMonthStartDate = new Date(today.getFullYear(), today.getMonth(),1);
    const thisMonthEndDate = new Date(today.getFullYear(), today.getMonth() + 1, 0);

    // Calculate the start and end dates for last month and this month
    const lastMonthStartDate = new Date(today.getFullYear(), today.getMonth()-1, 1);
    const lastMonthEndDate = new Date(today.getFullYear(), today.getMonth(), 0);

    // Update charts with fetched data
    const pendingBooksData = await fetchData('https://localhost:44310/api/Borrow/getallborrowedbooks'); 
    const checkedoutBooksData = await fetchData('https://localhost:44310/api/Checkout/getallcheckedoutbooks');
    const checkedInBooksData = await fetchData('https://localhost:44310/api/Borrow/getallcheckdInbooks');

    console.log('Pending Books Data:', pendingBooksData);
    console.log('Checkedout Books Data:', checkedoutBooksData);
    console.log('CheckedIn Books Data:', checkedInBooksData);

    if (pendingBooksData && checkedoutBooksData && checkedInBooksData) {
        // Calculate book counts for each status and date range
        const lastMonthPending = countBooksByStatusAndDate(pendingBooksData, 'Pending Book', lastMonthStartDate, lastMonthEndDate);
        const thisMonthPending = countBooksByStatusAndDate(pendingBooksData, 'Pending Book', thisMonthStartDate, thisMonthEndDate);

        const lastMonthCheckedOut = countBooksByStatusAndDate(checkedoutBooksData, 'Checked Out', lastMonthStartDate, lastMonthEndDate);
        const thisMonthCheckedOut = countBooksByStatusAndDate(checkedoutBooksData, 'Checked Out', thisMonthStartDate, thisMonthEndDate);

        const lastMonthCheckedIn = countBooksByStatusAndDate(checkedInBooksData, 'Checked In', lastMonthStartDate, lastMonthEndDate);
        const thisMonthCheckedIn = countBooksByStatusAndDate(checkedInBooksData, 'Checked In', thisMonthStartDate, thisMonthEndDate);

        // Calculate the total number of books for last month and this month
        const lastMonthTotal = lastMonthPending + lastMonthCheckedOut + lastMonthCheckedIn;
        const thisMonthTotal = thisMonthPending + thisMonthCheckedOut + thisMonthCheckedIn;

        // Calculate percentages
        const lastMonthPendingPercentage = (lastMonthPending / lastMonthTotal) * 100;
        const thisMonthPendingPercentage = (thisMonthPending / thisMonthTotal) * 100;

        const lastMonthCheckedOutPercentage = (lastMonthCheckedOut / lastMonthTotal) * 100;
        const thisMonthCheckedOutPercentage = (thisMonthCheckedOut / thisMonthTotal) * 100;

        const lastMonthCheckedInPercentage = (lastMonthCheckedIn / lastMonthTotal) * 100;
        const thisMonthCheckedInPercentage = (thisMonthCheckedIn / thisMonthTotal) * 100;

              console.log('Last Month Pending Percentage:', lastMonthPendingPercentage);
             console.log('This Month Pending Percentage:', thisMonthPendingPercentage);
             console.log('Last Month Checkedout Percentage:', lastMonthCheckedOutPercentage);
             console.log('This Month Checkedout Percentage:', thisMonthCheckedOutPercentage);
             console.log('Last Month Checkedin Percentage:', lastMonthCheckedInPercentage);
             console.log('This Month Checkedouin Percentage:', thisMonthCheckedInPercentage);


   // Create the grouped bar chart
   const groupedBarChartConfig = {
    type: 'bar',
    data: {
        labels: ['Last Month', 'This Month'],
        datasets: [
            {
                label: 'Pending Books',
                data: [lastMonthPendingPercentage, thisMonthPendingPercentage],
                backgroundColor: [
                    'rgba(255, 165, 0, 0.6)', // Orange for last month
                    'rgba(255, 165, 0, 0.8)', // Orange for this month
                ],
                borderColor: [
                    'rgba(255, 165, 0, 1)',
                    'rgba(255, 165, 0, 1)',
                ],
                borderWidth: 1
            },
            {
                label: 'Checked Out Books',
                data: [lastMonthCheckedOutPercentage, thisMonthCheckedOutPercentage],
                backgroundColor: [
                    'rgba(75, 75, 75, 0.6)', // Dark Grey for last month
                    'rgba(75, 75, 75, 0.8)', // Dark Grey for this month
                ],
                borderColor: [
                    'rgba(75, 75, 75, 1)',
                    'rgba(75, 75, 75, 1)',
                ],
                borderWidth: 1
            },
            {
                label: 'Checked In Books',
                data: [lastMonthCheckedInPercentage, thisMonthCheckedInPercentage],
                backgroundColor: [
                    'rgba(255, 255, 0, 0.6)', // Yellow for last month
                    'rgba(255, 255, 0, 0.8)', // Yellow for this month
                ],
                borderColor: [
                    'rgba(255, 255, 0, 1)',
                    'rgba(255, 255, 0, 1)',
                ],
                borderWidth: 1
            }
        ]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true,
                ticks: {
                    stepSize: 1
                }
            }
        }
    }
}

        // Create the grouped bar chart and pass the corresponding data arrays
        var groupedBarChartCtx = document.getElementById("GroupedBarChart").getContext("2d");
        new Chart(groupedBarChartCtx, groupedBarChartConfig);
}
});









 
