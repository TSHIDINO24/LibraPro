// Function to group conditions by type and list descriptions
function groupConditionsByType(conditions) {
    const groupedConditions = {};

    conditions.forEach(condition => {
        if (!groupedConditions[condition.conditionType]) {
            groupedConditions[condition.conditionType] = {
                conditionId: condition.conditionId,
                descriptions: [],
            };
        }

        groupedConditions[condition.conditionType].descriptions.push(condition.conditionDescription);
    });

    return groupedConditions;
}

// Function to send a POST request to your API
async function postBookConditionData(bookId, userId, bookAuthor, bookTitle,conditionId, conditionType) {
    try {
        // Construct the data object to be sent in the request
        const data = {
            bookId: bookId,
            userId: userId,
            bookAuthor: bookAuthor,
            bookTitle: bookTitle,
            conditionId: conditionId,
            conditionType: conditionType
            
        };

         // Log the data before sending the request
        console.log('Data to be sent:', JSON.stringify(data));

        // Send a POST request to your API endpoint
        const response = await fetch('https://localhost:44310/api/BookEvaluations/addEvaluation', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        });

        if (response.ok) {
            // Handle a successful response
            console.log('Book condition data successfully posted to the API');

            //Redirect to previous page with filter parameters
           // const filterParameter = localStorage.getItem('filterParameter');
            //if(filterParameter){
              //  window.location.href = 'CheckedOutBooksPage.html' + queryString;
           // }
            //else {
                //Handle case wher filter parameter is not available 
              //  console.error('Filter parameter not available');
            //}
            window.history.back();
        
        } else {
            // Handle an error response
            console.error('Failed to post book condition data to the API');
        }
    } catch (error) {
        // Handle any errors that occur during the POST request
        console.error('Error posting book condition data:', error);
    }
}

//let queryString = '';

// Function to fetch conditions data from an API and populate the table
async function fetchConditionsFromAPIAndPopulateTable() {
    try {
        // Make a GET request to your API endpoint
        const response = await fetch('https://localhost:44310/api/BookConditions');

        if (response.ok) {
            const conditions = await response.json();

            // Group conditions by condition type and descriptions
            const groupedConditions = groupConditionsByType(conditions);

            // Get the table body element to populate data
            const tableBody = document.querySelector('#myTable tbody');

            // Loop through the grouped conditions and populate the table
            Object.entries(groupedConditions).forEach(([conditionType, conditionData]) => {
                // Create a row for each condition type
                const row = document.createElement('tr');

                // Create cells for No. (conditionId), condition type, description, and a checkbox
                const conditionIdCell = document.createElement('td');
                conditionIdCell.textContent = conditionData.conditionId;

                const conditionTypeCell = document.createElement('td');
                conditionTypeCell.textContent = conditionType;

                const conditionDescriptionCell = document.createElement('td');
                const descriptionList = document.createElement('ul');

                conditionData.descriptions.forEach(description => {
                    const descriptionItem = document.createElement('li');
                    descriptionItem.textContent = description;
                    descriptionList.appendChild(descriptionItem);
                });

                conditionDescriptionCell.appendChild(descriptionList);

                const actionCell = document.createElement('td');
                const checkbox = document.createElement('input');
                checkbox.type = 'checkbox';
                checkbox.classList.add('custom-checkbox');
                actionCell.appendChild(checkbox);

                // Set the data-attribute for the row to store conditionId
                row.dataset.conditionId = conditionData.conditionId;

                // Append cells to the row
                row.appendChild(conditionIdCell);
                row.appendChild(conditionTypeCell);
                row.appendChild(conditionDescriptionCell);
                row.appendChild(actionCell);

                // Append the row to the table body
                tableBody.appendChild(row);
            });
 
            let conditionId;
            let conditionType;
          // Event listener for the Submit button
          const submitButton = document.getElementById('updateSubmitBtn');
          submitButton.addEventListener('click', function () {
              // Get all checkboxes
              const checkboxes = document.querySelectorAll('.custom-checkbox');

              // Count the number of selected checkboxes
              let selectedCount = 0;
              let selectedConditionId = null;
              let selectedConditionType = null;

              // Loop through checkboxes and check if they are selected
              checkboxes.forEach(checkbox => {
                  if (checkbox.checked) {
                      selectedCount++;
                      // Get the condition ID from the data attribute
                      selectedConditionId = checkbox.closest('tr').querySelector('td:nth-child(1)').textContent;

                      // Get the corresponding condition type
                      selectedConditionType = checkbox.closest('tr').querySelector('td:nth-child(2)').textContent;
                  }
              });

              // Access the query parameters from the URL
              const queryString = window.location.search;
              const urlParams = new URLSearchParams(queryString);
              const bookId = urlParams.get('bookId');
              const userId = urlParams.get('userId');
              const bookAuthor = urlParams.get('bookAuthor');
              const bookTitle = urlParams.get('bookTitle');

              // Check if exactly one condition was selected
              if (selectedCount === 1) {
                  // Send the selected condition
                  const conditionId = selectedConditionId;
                  const conditionType = selectedConditionType;

                  // Call the function to send a POST request with the collected data
                  postBookConditionData(bookId, userId, bookAuthor, bookTitle, conditionId, conditionType);

                  // Clear any previous error messages
                  document.getElementById('error-message').textContent = '';
              } else {
                  // Handle the case where zero or multiple conditions were selected
                  const errorMessage = 'Please select exactly one condition.';
                  document.getElementById('error-message').textContent = errorMessage;
              }
          });

      } else {
          // Handle the error
          console.error('API request failed with status:', response.status);
          const errorElement = document.createElement('p');
          errorElement.textContent = 'Failed to fetch conditions data from the API.';
          document.body.appendChild(errorElement);
      }
  } catch (error) {
      console.error('Error fetching data:', error);
  }
}

// Call the function to fetch data from the API and populate the table when the page loads
window.addEventListener('load', fetchConditionsFromAPIAndPopulateTable);
