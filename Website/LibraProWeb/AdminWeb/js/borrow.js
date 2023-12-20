var tableBody = document.getElementById('Borrowdata');

// Filter the table by the BorrowCode
function filterTableByBorrowCode() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
  
    // Loop through all table rows, and hide those that don't match the search query
    for (i = 0; i < tr.length; i++) {
      td = tr[i].getElementsByTagName("td")[6]; // BorrowCode is in the 7th column (index 6)
      if (td) {
        txtValue = td.textContent || td.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
          tr[i].style.display = "";
        } else {
          tr[i].style.display = "none";
        }
      }
    }
}



        function populateTable(Borrowdata) {
            var tableBody = document.getElementById('Borrowdata');
            tableBody.innerHTML = ''; // Clear existing data
        
            Borrowdata.forEach(function (borrow) {
                var row = document.createElement('tr');
        
              //  var borrowUserIdCell = document.createElement('td');
                //borrowUserIdCell.textContent = borrow.userId;
                //row.appendChild(borrowUserIdCell);
        
        
                // var bookIdCell = document.createElement('td');
                // bookIdCell.textContent = borrow.bookId;
                // row.appendChild(bookIdCell);
        
                
                 var borrowIdCell = document.createElement('td');
                 borrowIdCell.textContent = borrow.borrowId;
                 row.appendChild(borrowIdCell);

                //var catIdCell = document.createElement('td');
                //catIdCell.textContent = borrow.categoryId;
                //row.appendChild(catIdCell);

                var catCell = document.createElement('td');
                catCell.textContent = borrow.categoryName;
                row.appendChild(catCell);
        
                var borrowbookTitleCell = document.createElement('td');
                borrowbookTitleCell.textContent = borrow.bookTitle;
                row.appendChild(borrowbookTitleCell);
        
                var borrowauthorCell = document.createElement('td');
                borrowauthorCell.textContent = borrow.bookAuthor;
                row.appendChild(borrowauthorCell);
        
                const borrowDateCell = document.createElement('td');
                borrowDateCell.textContent = borrow.borrowDate;
                row.appendChild(borrowDateCell);
        
                const borrowReturnedDateCell = document.createElement('td');
                borrowReturnedDateCell.textContent = borrow.borrowReturnedDate;
                row.appendChild(borrowReturnedDateCell);
        
                var borrowbookCodeCell = document.createElement('td');
                borrowbookCodeCell.textContent = borrow.borrowCode;
                row.appendChild(borrowbookCodeCell);
        
                var borrowbookStatusCell = document.createElement('td');
                borrowbookStatusCell.textContent = borrow.status;
                row.appendChild(borrowbookStatusCell);
        
                var actionCell = document.createElement('td');
                var borrowButton = document.createElement('button');
                borrowButton.className = 'action-button';
                borrowButton.textContent = 'Borrow';
                    borrowButton.onclick = function () {
                    toggleBorrowButton(borrowButton, borrow);
                    };                                                                                     
               
                actionCell.appendChild(borrowButton);
                row.appendChild(actionCell);
        
                tableBody.appendChild(row);
            });
          }
              
       // Fetch getallborrowedbooks data from the API
fetch('https://localhost:44310/api/Borrow/getallborrowedbooks')
.then(response => {
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    return response.json();
})
.then(data => {
    // Check if the response data is valid JSON
    if (data && typeof data === 'object') {
        console.log('Fetched data:', data);
        populateTable(data);
    } else {
        throw new Error('Invalid JSON data received from the API');
    }
})
.catch(error => {
    console.error('Error fetching or parsing data:', error);
});

        function toggleBorrowButton(button, borrow) {
            var row = button.closest('tr');
            var statusCell = row.querySelector('td:nth-child(8)'); // Index 11 corresponds to the "Status" column
        
          // Inside the toggleBorrowButton function
        if (button.textContent === 'Borrow') {
            // Update status to "CheckedOut"
            statusCell.textContent = 'Checked Out';
            
            // Call the function to update information in the CheckedOut table
            updateCheckedOutTable(borrow);
        
            //remove the borrow button when book is checked out
            button.remove();
        }
        }
        
        function updateCheckedOutTable(borrow) {
            // Prepare the data to be sent in the POST request
            const checkoutData = {
                userId: borrow.userId,
                bookId: borrow.bookId,
                borrowId: borrow.borrowId,
                borrowCode: borrow.borrowCode,
                borrowDate: borrow.borrowDate,
                borrowReturnedDate: borrow.borrowReturnedDate,
                bookImage: borrow.bookImage,
                bookTitle: borrow.bookTitle,
                bookAuthor: borrow.bookAuthor,
                status: "Checked Out",
                categoryId: borrow.categoryId,
                categoryName: borrow.categoryName
            };
        
            // Send a PUT request to update the status
            fetch('https://localhost:44310/api/Borrow/updateStatus', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(checkoutData),
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Network response was not ok (Status ${response.status})`);
                }
                return response.json();
            })
            .then(data => {
                if (data.success) {
                    console.log('Status updated successfully');
                } else {
                    console.error('Error updating status:', data.message);
                }
            })
            .catch(error => console.error('Error updating status:', error));
        
            // Send a POST request to add the borrowed book to the CheckedOut table
            fetch('https://localhost:44310/api/Checkout/checkoutbooks', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(checkoutData)
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Network response was not ok (Status ${response.status})`);
                }
                return response.json();
            })
            .then(data => {
                console.log('Book added to CheckedOut:', data);
                
            // Check if all filtered rows have a status of "Checked Out"
            const allCheckedOut = Array.from(tr).every(row => {
                const statusCell = row.querySelector('td:nth-child(8)'); //status column
                return statusCell.textContent === 'Checked Out';
            });
            
            // If all rows are checked out, refresh the page
            if (allCheckedOut) {
                location.reload(); 
            }
            })
            .catch(error => {
                console.error('Error adding book to CheckedOut:', error);
            });
        }
        
    

   