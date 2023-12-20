// Store filter value in session storage when the filter input changes
var input = document.getElementById("myInput");
input.addEventListener("input", function () {
    sessionStorage.setItem("filterValue", input.value);
});

// Retrieve filter value from session storage and apply it to the filter input
var storedFilterValue = sessionStorage.getItem("filterValue");
if (storedFilterValue) {
    input.value = storedFilterValue;
    filterTableByBorrowCode(); // Apply the filter initially
}

// Reload the page when needed (page show event)
window.addEventListener("pageshow", function(event) {
    var historyTraversal = event.persisted || (typeof window.performance !== "undefined" && window.performance.navigation.type === 2);
    if (historyTraversal) {
        window.location.reload();
    }
});

var tableBody = document.getElementById('Checkoutdata');

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
      td = tr[i].getElementsByTagName("td")[7]; // BorrowCode is in the 8th column (index 7)
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
        ///////////////////////////////////////////////////////////checked out books to checkin
        function populateTable(Checkoutdata) {
            var tableBody = document.getElementById('Checkoutdata');
            tableBody.innerHTML = ''; // Clear existing data
        
            Checkoutdata.forEach(function (CheckIn) {
                var row = document.createElement('tr');
        
                var borrowUserIdCell = document.createElement('td');
                borrowUserIdCell.textContent = CheckIn.userId;
                row.appendChild(borrowUserIdCell);
        
        
                var bookIdCell = document.createElement('td');
                bookIdCell.textContent = CheckIn.bookId;
                row.appendChild(bookIdCell);
        
                
                var borrowIdCell = document.createElement('td');
                borrowIdCell.textContent = CheckIn.borrowId;
                row.appendChild(borrowIdCell);
        
        
                var borrowbookTitleCell = document.createElement('td');
                borrowbookTitleCell.textContent = CheckIn.bookTitle;
                row.appendChild(borrowbookTitleCell);
        
                var borrowauthorCell = document.createElement('td');
                borrowauthorCell.textContent = CheckIn.bookAuthor;
                row.appendChild(borrowauthorCell);
        
                const borrowDateCell = document.createElement('td');
                borrowDateCell.textContent = CheckIn.borrowDate;
                row.appendChild(borrowDateCell);
        
                const borrowReturnedDateCell = document.createElement('td');
                borrowReturnedDateCell.textContent = CheckIn.borrowReturnedDate;
                row.appendChild(borrowReturnedDateCell);
        
                var borrowbookCodeCell = document.createElement('td');
                borrowbookCodeCell.textContent = CheckIn.borrowCode;
                row.appendChild(borrowbookCodeCell);
        
                var borrowbookStatusCell = document.createElement('td');
                borrowbookStatusCell.textContent = CheckIn.status;
                row.appendChild(borrowbookStatusCell);
        
                var actionCell = document.createElement('td');
                var checkInButton = document.createElement('button');
                checkInButton.className = 'action-button';
                checkInButton.textContent = 'CheckIn';
                    checkInButton.onclick = function () {
                        toggleCheckInButton(checkInButton, CheckIn, borrowbookStatusCell, row); // Pass the row
                    };
            
                    actionCell.appendChild(checkInButton);
                    row.appendChild(actionCell);
            
                    tableBody.appendChild(row);
                });
            }
            
            // Fetch getallborrowedbooks data from the API
            fetch('https://localhost:44310/api/Checkout/getallcheckedoutbooks')
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    console.log('Fetched data:', data);
                    populateTable(data);
                })
                .catch(error => console.error('Error fetching data:', error));
            
            /// when checkin button is clicked the info is deleted on the table and the books are incremented
            function toggleCheckInButton(button, CheckIn, statusCell, row) { // Pass the row
                console.log('CheckIn button clicked');
            
                if (button.textContent === 'CheckIn') {
                    statusCell.textContent = 'Checked In';
                    button.remove();
                    updateCheckedOutTable(CheckIn, row); // Pass the row
                }
            }

            
            function updateCheckedOutTable(CheckIn, row) { // Pass the row
                var borrowId = CheckIn.borrowId; // Get borrowId from the data object
            
                fetch('https://localhost:44310/api/Borrow/updateStatus', {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        borrowId: borrowId, // Use the borrowId obtained from the data object
                        status: 'Checked In',
                    }),
                })
                    .then(response => {
                        return response.json();
                    })
                    .then(data => {
                        if (data.message === 'Status successful updated') {
                            console.log('Status updated successfully');
                            // Call the function to delete the Borrow table row
                            deleteBorrowTableRow(row); // Pass the row
                        } else {
                            console.log('Status not updated successfully');
                        }
                    });
            }
            
            function deleteBorrowTableRow(row) { // Accept the row as a parameter
                console.log('Attempting to delete row:', row);
                var borrowId = row.querySelector('td:nth-child(3)').textContent;
            
                // Extract the relevant information from the row
                var bookIdCell = row.querySelector('td:nth-child(2)');
                var userIdCell = row.querySelector('td:nth-child(1)');
                var bookAuthorCell = row.querySelector('td:nth-child(5)');
                var bookTitleCell = row.querySelector('td:nth-child(4)');
            
                var bookId = bookIdCell ? bookIdCell.textContent : '';
                var userId = userIdCell ? userIdCell.textContent : '';
                var bookAuthor = bookAuthorCell ? bookAuthorCell.textContent : '';
                var bookTitle = bookTitleCell ? bookTitleCell.textContent : '';
            
                fetch(`https://localhost:44310/api/Checkout/checkInbycode/${borrowId}`, {
                    method: 'DELETE',
                })
                    .then(response => {
                        if (response.ok) {
                            tableBody.removeChild(row);
                            console.log('Successfully checked in');
            
                            // Construct URL for the BookCondition page with query parameters
                            var bookConditionUrl = `BookCondition.html?bookId=${bookId}&userId=${userId}&bookAuthor=${encodeURIComponent(bookAuthor)}&bookTitle=${encodeURIComponent(bookTitle)}`;
            
                            // Redirect to the BookCondition page
                            window.location.href = bookConditionUrl;
                        } else {
                            console.error('Error checking in the book');
                        }
                    })
                    .catch(error => {
                        console.error('Error checking in the book', error);
                    });
            }
                
        
       