///////////////////////////////////////CHECKED OUT BOOKS BY  PIE CHART
//////////////////////////////////////Category Trend
//function to generate an array of random colours
function generateRandomColours(count){
    const colours = [];

    for(let i = 0; i< count; i++)
    {
        const hue = (360 / count) * i; //distribute colours evenly
        const saturation = 75; 
        const lightness = 80;
        const colour = `hsl(${hue}, ${saturation}%, ${lightness}%`; 
        colours.push(colour);
    }
    return colours;
}

// Function to fetch data from the API
async function fetchData(apiEndpoint) {
    try {
        const response = await fetch(apiEndpoint);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching data:', error);
        return null;
    }
}

//fetch data from APIs
const apiEndpoint1 = 'https://localhost:44310/api/Borrow/getallborrowedbooks';
const apiEndpoint2 = 'https://localhost:44310/api/Checkout/getallcheckedoutbooks';
const apiEndpoint3 = 'https://localhost:44310/api/Borrow/getallcheckdInbooks';

// Normalize category names by converting to lowercase and removing whitespace
function normalizeCategoryName(categoryName) {
    return categoryName.toLowerCase().trim();
}

// Define API endpoints for both APIs
Promise.all([fetchData(apiEndpoint1), fetchData(apiEndpoint2), fetchData(apiEndpoint3)])
   .then(([data1, data2, data3]) => {
    const combineData = [...data1, ...data2, ...data3]; // Combine API data

    // Count categories
    const categoryCounts = {};
    combineData.forEach(item => {
        const categoryName = item.categoryName;

        if (!categoryCounts[categoryName]) {
            categoryCounts[categoryName] = 1;
        } else {
            categoryCounts[categoryName]++;
        }
    });

    // Calculate percentages
    const totalItems = combineData.length;
    const categoryPercentages = {};
    for (const categoryName in categoryCounts) {
        categoryPercentages[categoryName] = (categoryCounts[categoryName] / totalItems) * 100;
    }

    // Create arrays for labels and data
    const labels = Object.keys(categoryCounts);
    const dataValues = Object.values(categoryPercentages);

    // Random colors
    const colors = generateRandomColours(labels.length);

    const PieData = {
        datasets: [{
            data: dataValues,
            backgroundColor: colors,
            borderColor: 'white',
        }],
        labels: labels
    };

    const PieOptions = {
        responsive: true,
        animation: {
            animateScale: true,
            animateRotate: true, 
        },
        cutoutPercentage: 50,
    };

    const piectx = document.getElementById("pieChart").getContext("2d");
    new Chart(piectx, {
        type: 'pie',
        data: PieData,
        options: PieOptions,
    });
});
