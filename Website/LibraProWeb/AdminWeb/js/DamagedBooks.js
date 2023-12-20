function populateTable(damagedBook) {
    var tableBody = document.getElementById('damagedBooks');
    tableBody.innerHTML = ''; // Clear existing data

    var bookCounts = {};

    damagedBook.forEach(function (book) {
        var row = document.createElement('tr');

        var bookIdCell = document.createElement('td');
        bookIdCell.textContent = book.bookId;
        row.appendChild(bookIdCell);

        var bookTitleCell = document.createElement('td');
        bookTitleCell.textContent = book.bookTitle;
        row.appendChild(bookTitleCell);

        var bookAuthorCell = document.createElement('td');
        bookAuthorCell.textContent = book.bookAuthor;
        row.appendChild(bookAuthorCell);

        var DateCell = document.createElement('td');
        DateCell.textContent = book.evaluationDate;
        row.appendChild(DateCell);

        var statusCell = document.createElement('td');
        statusCell.textContent = book.status;
        row.appendChild(statusCell);

        // Check if the status is "Evaluated" and skip adding the button
        if (book.status !== "Evaluated") {
            var actionCell = document.createElement('td'); 
            var EvaluateButton = document.createElement('button');
            EvaluateButton.className = 'action-button';
            EvaluateButton.textContent = 'Inspect';
            EvaluateButton.onclick = function () {
                openPopup(this); // Open the pop-up form
            };
            actionCell.appendChild(EvaluateButton);
            row.appendChild(actionCell); 
        } else {
            // Status is "Evaluated," so add an empty cell
            var emptyCell = document.createElement('td');
            row.appendChild(emptyCell);
        }

        tableBody.appendChild(row);
    });
}

// Fetch condition books data from the API
fetch('https://localhost:44310/api/BookEvaluations')
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        // Check if the response data is valid JSON
        if (Array.isArray(data)) {
            // Filter books with conditionType "Damaged" and "Poor"
            const damagedBooks = data.filter(book => book.conditionType === "Damaged Condition" || book.conditionType === "Poor Condition");

            console.log('Fetched data:', damagedBooks);
            populateTable(damagedBooks);
        } else {
            throw  Error('Invalid JSON data received from the API');
        }
    })
    .catch(error => {
        console.error('Error fetching or parsing data:', error);
    });

function openPopup(button) {
    var popup = document.getElementById("damagedBookPopup");
    popup.style.display = "block";

    // Get the table row that contains the clicked button
    var tableRow = button.closest('tr');

    // Retrieve book title and book number from the table row
    var bookId = tableRow.querySelector('td:nth-child(1)').textContent;
    var bookTitle = tableRow.querySelector('td:nth-child(2)').textContent;
    var bookAuthor = tableRow.querySelector('td:nth-child(3)').textContent;
    var statusCell = tableRow.querySelector('td:nth-child(5)');

    // Update the status to "Evaluated"
    statusCell.textContent = "Evaluated";

    // Populate the form with book details
    document.getElementById("bookNo").value = bookId || "";
    document.getElementById("bookTitle").value = bookTitle || "";
    document.getElementById("bookAuthor").value = bookAuthor || "";
    document.getElementById("status").value = "Evaluated"; // Update the status field
    document.getElementById("damageType").value = "";
    document.getElementById("repairPrice").value = "";
    document.getElementById("replacePrice").value = "";

    // Store book data in a data attribute for future reference
    popup.setAttribute("data-book-id", bookId);
}

// Function to close the pop-up form
function closePopup() {
    var popup = document.getElementById("damagedBookPopup");
    popup.style.display = "none";
}

// Event listener for the "Evaluate" button click
document.getElementById("evaluatebtn").addEventListener("click", function (event) {
    event.preventDefault(); // Prevent form submission

    // Get the values from the form inputs
    var damageType = document.getElementById("damageType").value;
    var repairPriceInput = document.getElementById("repairPrice").value;
    var replacePriceInput = document.getElementById("replacePrice").value;
    var bookId = document.getElementById("bookNo").value;
    var bookTitle = document.getElementById("bookTitle").value;
    var bookAuthor = document.getElementById("bookAuthor").value;
    var status = document.getElementById("status").value;

    // Ensure that bookId, bookTitle, and bookAuthor are not null or empty
    if (!bookId || !bookTitle || !bookAuthor) {
        console.error('Invalid bookId, bookTitle, or bookAuthor');
        return;
    }

     // Parse repairPrice and replacePrice as decimals
     var repairPrice = parseFloat(repairPriceInput);
     var replacePrice = parseFloat(replacePriceInput); 

    // Ensure that repairPrice and replacePrice are not NaN
if (isNaN(repairPrice) || isNaN(replacePrice)) {
    console.error('Invalid repairPrice or replacePrice');
    return;
}

    // Create an object with the entered data
    var newDamagedBook = {
        bookId: bookId,
        bookTitle: bookTitle,
        bookAuthor: bookAuthor,
        damageType: damageType,
        repairCost: repairPrice,
        replaceCost: replacePrice,
        status: status
    };
    console.log(newDamagedBook);

    // Perform a POST request to add the new entry to the API
    fetch('https://localhost:44310/api/DamagedBook/addEvaluation', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newDamagedBook),
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        // Handle the response from the API
        console.log('Data added successfully:', data);

        // Close the pop-up form
        closePopup();
    })
    .catch(error => {
        console.error('Error adding data:', error);
    });
});

// Event listener for the close button click
document.getElementById("closePopupD").addEventListener("click", function () {
    closePopup();
});



