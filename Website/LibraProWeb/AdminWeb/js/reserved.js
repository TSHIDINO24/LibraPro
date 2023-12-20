function fetchData(apiEndpoint) {
    return fetch(apiEndpoint)
        .then(response => response.json())
        .then(data => data);
}

// Fetch data from the "getallreserved" and "getallborrowed" endpoints
Promise.all([
    fetchData('https://localhost:44310/api/Statistics/getallreserved'),
    fetchData('https://localhost:44310/api/Statistics/getallborrowed')
])
.then(data => {
    const reservedData = data[0]; // Data from the "getallreserved" endpoint
    const borrowedData = data[1]; // Data from the "getallborrowed" endpoint

    // Extract book title counts for "Reserved" (Dataset 1)
    const bookCounts1 = {};
    reservedData.forEach(item => {
        const bookTitle = item.bookTitle;
        if (bookCounts1[bookTitle]) {
            bookCounts1[bookTitle]++;
        } else {
            bookCounts1[bookTitle] = 1;
        }
    });

    // Extract book title counts for "Borrowed" (Dataset 2)
    const bookCounts2 = {};
    borrowedData.forEach(item => {
        const bookTitle = item.bookTitle;
        if (bookCounts2[bookTitle]) {
            bookCounts2[bookTitle]++;
        } else {
            bookCounts2[bookTitle] = 1;
        }
    });

    // Combine the book counts from both datasets
    const combinedBookCounts = {};

    // Merge counts from Dataset 1
    Object.keys(bookCounts1).forEach(bookTitle => {
        combinedBookCounts[bookTitle] = {
            dataset1: bookCounts1[bookTitle] || 0,
            dataset2: bookCounts2[bookTitle] || 0,
        };
    });

    // Merge counts from Dataset 2
    Object.keys(bookCounts2).forEach(bookTitle => {
        if (!(bookTitle in combinedBookCounts)) {
            combinedBookCounts[bookTitle] = {
                dataset1: 0,
                dataset2: bookCounts2[bookTitle] || 0,
            };
        }
    });

    // Extract book titles and counts for both datasets
    const titles = Object.keys(combinedBookCounts);
    const countsDataset1 = titles.map(title => combinedBookCounts[title].dataset1);
    const countsDataset2 = titles.map(title => combinedBookCounts[title].dataset2);

    // Create a bar chart using Chart.js
    const ctx = document.getElementById('bookChart').getContext('2d');
    const bookChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: titles,
            datasets: [
                {
                    label: 'Reserved',
                    data: countsDataset1,
                    backgroundColor: 'rgba(75, 192, 192, 0.6)', // Bar color for Dataset 1
                    barPercentage: 0.4, // Adjust the width of bars for Dataset 1
                    categoryPercentage: 0.5, // Adjust the spacing between bars for Dataset 1
                },
                {
                    label: 'Borrowed',
                    data: countsDataset2,
                    backgroundColor: 'rgba(255, 99, 132, 0.6)', // Bar color for Dataset 2
                    barPercentage: 0.4, // Adjust the width of bars for Dataset 2
                    categoryPercentage: 0.5, // Adjust the spacing between bars for Dataset 2
                },
            ],
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
})
.catch(error => {
    console.error('Error fetching data:', error);
});