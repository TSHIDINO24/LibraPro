const apiEndpoint = 'https://localhost:44310/api/Notification/usernotification';
function getCookie(name) {
  const value = "; " + document.cookie;
  const parts = value.split("; " + name + "=");
  if (parts.length === 2) return parts.pop().split(";").shift();
}

const authToken = getCookie("sessionToken");

const headers = new Headers({
  'Authorization': `Bearer ${authToken}`,
  'Content-Type': 'application/json'
});
async function fetchData(apiEndpoint) {
  try {
    const response = await fetch(apiEndpoint, { headers });
    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Error fetching data:', error);
  }
}

document.addEventListener("DOMContentLoaded", async function () {

  // Fetch data from the APIs
  const notification = await fetchData('https://localhost:44310/api/Notification/usernotification');


  if (notification) {
    // Calculate counts based on list lengths
    const notificationTotal = notification.length;
    // Update the HTML with calculated totals
    document.getElementById("notificationTotal").textContent = notificationTotal;

  }
});
const searchButton = document.getElementById('searchButton');
const searchInput = document.getElementById('searchInput');
const bookResult = document.getElementById('bookResult');

searchButton.addEventListener('click', async () => {
  const searchTerm = searchInput.value.trim();
  if (searchTerm) {
    try {
      const response = await fetch(`https://localhost:44310/api/Book/getbooktitle?_BookTitle=${encodeURIComponent(searchTerm)}`);
      const data = await response.json();

      if (data) {
        const book = data;
        bookResult.innerHTML = `
        <img style="width:150px; height:150px;" src="${book.bookImage}/>"
        <p>Book Title: ${book.bookTitle}
        </p><p>Author: ${book.bookAuthor}</p>
        `;
      } else {
        bookResult.innerHTML = 'No results found.';
      }
    } catch (error) {
      console.error('Error fetching book:', error);
      bookResult.innerHTML = 'An error occurred while fetching the book.';
    }
  } else {
    bookResult.innerHTML = 'Please enter a book title.';
  }
});

const slider = document.querySelector('.slider');

async function fetchAndPopulateItems() {
  try {
    const response = await fetch('https://localhost:44310/api/Book/allbooks');
    const data = await response.json();

    data.forEach(item => {
      const itemElement = document.createElement('div');
      itemElement.classList.add('item');

      const img = document.createElement('img');
      img.src = item.bookImage;


      itemElement.appendChild(img);
      slider.appendChild(itemElement);
    });

    startSlider();
  } catch (error) {
    console.error('Error fetching data:', error);
  }
}

function startSlider() {
  const items = slider.querySelectorAll('.item');
  let currentItem = 0;

  function slideNext() {
    currentItem = (currentItem + 1) % items.length;
    updateSlider();
  }

  function updateSlider() {
    const offset = -currentItem * 100;
    slider.style.transform = `translateX(${offset}%)`;
  }

  setInterval(slideNext, 3000);
}

fetchAndPopulateItems();