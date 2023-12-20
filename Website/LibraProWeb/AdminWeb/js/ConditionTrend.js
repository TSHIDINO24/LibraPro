  ////////////////////////////LINE GRAPH FOR BOOK CONDITIONS
    async function fetchBookConditionData() {
        try {
            const response = await fetch('https://localhost:44310/api/BookEvaluations');
            const data = await response.json();
            return data;
        } catch (error) {
            console.error('Error fetching book condition data:', error);
            return null;
        }
    }

    function calculateBookConditionPercentages(data) {
        const conditionCounts = {};
        const totalBooks = data.length;
    
        data.forEach(item => {
            const conditionType = item.conditionType;
            conditionCounts[conditionType] = (conditionCounts[conditionType] || 0) + 1;
        });
    
        const percentages = Object.keys(conditionCounts).map(conditionType => {
            const count = conditionCounts[conditionType];
            return (count / totalBooks) * 100;
        });
    
        return {
            labels: Object.keys(conditionCounts),
            values: percentages,
        };
    }

    function createLineGraph(data) {
        const { labels, values } = calculateBookConditionPercentages(data);
    
        const ctx = document.getElementById('linegraph').getContext('2d');
    
        new Chart(ctx, {
            type: 'line',
            data: {
                labels: labels,
                datasets: [
                    {
                        label: 'Book Condition Percentage',
                        data: values,
                        fill: true,
                        borderColor:  'rgb(0, 0, 128)',
                        tension: 0.1,
                    },
                ],
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true,
                        max: 100,
                    },
                },
            },
        });
    }
    // Fetch book condition data and create the line graph
fetchBookConditionData()
.then(data => {
    if (data) {
        createLineGraph(data);
    }
})
.catch(error => console.error('Error:', error));


////when the manage button clicked redirect to manage damaged books page 
var manage = document.getElementById('manageDamagedBooks');

manage.addEventListener('click', function(){

    window.location.href = 'ManageDamagedBooks.html';
})