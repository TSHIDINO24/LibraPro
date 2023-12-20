function getCookie(name) {
    const value = "; " + document.cookie;
    const parts = value.split("; " + name + "=");
    if (parts.length === 2) return parts.pop().split(";").shift();
}

const authToken = getCookie("sessionToken");

const headers = {
    Authorization: `Bearer ${authToken}`,
    'Content-Type': 'application/json'
};

// Function to fetch data from the API
async function fetchData(apiEndpoint,headers) {
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
    
    const cartdata = await fetchData('https://littleorangeboard95.conveyor.cloud/api/Bag/getallbooks');

    if (cartdata) {
        // Calculate counts based on list lengths
        const cartTotal = cartdata.length;  
   
        // Update the HTML with calculated totals
        document.getElementById("cartCount").textContent = userTotal;
      
    }
});
