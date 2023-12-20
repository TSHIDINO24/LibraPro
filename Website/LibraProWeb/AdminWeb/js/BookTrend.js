 //////////////////////////////BOOKS TREND 
 // Define a function to fetch data from the API
 async function BooksfetchData(Endpoint) {
    try {
        const response = await fetch(Endpoint);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching data:', error);
        return null;
    }
}

// Define API endpoints for your data
const Endpoint1 = 'https://localhost:44310/api/Borrow/getallborrowedbooks';
const Endpoint2 = 'https://localhost:44310/api/Checkout/getallcheckedoutbooks';
const Endpoint3 = 'https://localhost:44310/api/Borrow/getallcheckdInbooks';



// Fetch data from all API endpoints
Promise.all([BooksfetchData(Endpoint1), BooksfetchData(Endpoint2), BooksfetchData(Endpoint3)])
    .then(([data1, data2, data3]) => {
        // Combine data from different endpoints into one array
         console.log('data1:', data1);
         console.log('Data2:', data2);
         console.log('Data3:', data3);
        const combineData = [...data1, ...data2, ...data3];

           // Create an object to store the most borrowed books by category
        const mostBorrowedBooksByCategory = {};

        // Iterate through the combined data and count the number of times borrowed for each unique book in each category
        combineData.forEach(item => {
            const categoryName = item.categoryName;
            const bookKey = `${item.bookId}_${categoryName}`;

            if (!mostBorrowedBooksByCategory[categoryName]) {
                mostBorrowedBooksByCategory[categoryName] = {};
            }

            if (!mostBorrowedBooksByCategory[categoryName][bookKey]) {
                mostBorrowedBooksByCategory[categoryName][bookKey] = {
                    refNo: item.bookId,
                    title: item.bookTitle,
                    author: item.bookAuthor,
                    borrowedCount: 0,
                };
            }

            mostBorrowedBooksByCategory[categoryName][bookKey].borrowedCount++;
        });

        // Function to get the top 10 borrowed books for each category
        function getTop10BorrowedBooks(categoryName) {
            const books = Object.values(mostBorrowedBooksByCategory[categoryName]);
            books.sort((a, b) => b.borrowedCount - a.borrowedCount);
            return books.slice(0, 10);
        }

        // Function to populate the HTML table with top 10 borrowed books in each category
        function populateTop10BorrowedBooksTable() {
            const tableBody = document.getElementById('BooksTrend');

            // Clear existing data
            tableBody.innerHTML = '';

            // Iterate through each category and add the top 10 borrowed books to the table
            for (const categoryName in mostBorrowedBooksByCategory) {
                const top10Books = getTop10BorrowedBooks(categoryName);

                top10Books.forEach(book => {
                    const row = document.createElement('tr');

                    const titleCell = document.createElement('td');
                    titleCell.textContent = book.title;
                    row.appendChild(titleCell);

                    const authorCell = document.createElement('td');
                    authorCell.textContent = book.author;
                    row.appendChild(authorCell);

                    tableBody.appendChild(row);
                });
            }
        }

        // Call the function to populate the HTML table with top 10 borrowed books in each category
        populateTop10BorrowedBooksTable();
    })
    .catch(error => console.error('Error fetching data:', error));