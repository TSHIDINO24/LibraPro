/////////////////////////////////////////////////////////////////TOTALS
// Function to fetch data from the API
async function TotalfetchData(apiEndpoint) {
    try {
        const response = await fetch(apiEndpoint);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching data:', error);
        return null;
    }
}

document.addEventListener("DOMContentLoaded", async function() {

    // Fetch data from the APIs
    const pendingOrdersData = await TotalfetchData('https://localhost:44310/api/Borrow/getallborrowedbooks');
    const checkedOutBooksData = await TotalfetchData('https://localhost:44310/api/Checkout/getallcheckedoutbooks');
    const bookEvaluationsData = await TotalfetchData('https://localhost:44310/api/BookEvaluations');

    if (pendingOrdersData && checkedOutBooksData && bookEvaluationsData) {
        // Calculate counts based on list lengths
        const pendingOrdersTotal = pendingOrdersData.length;
        const checkedOutBooksTotal = checkedOutBooksData.length;
    

        // Update the HTML with calculated totals
        document.getElementById("PendingOrdersTotal").textContent = pendingOrdersTotal;
        document.getElementById("CheckedOutBooksTotal").textContent = checkedOutBooksTotal;
       
        if (bookEvaluationsData) {
            // Filter book evaluations data for damaged books
            const damagedBooksData = bookEvaluationsData.filter(bookEval => bookEval.conditionType === "Damaged Condition");
    
            // Calculate the count of damaged books
            const damagedBooksTotal = damagedBooksData.length;
    
            // Display the damaged books count
            document.getElementById("DamagedBooksTotal").textContent = damagedBooksTotal;
        }
    }
});
