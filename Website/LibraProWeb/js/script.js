const slider = document.querySelector('.slider');
const slides = document.querySelectorAll('.slide');
let currentIndex = 0;

function showSlide(index) {
    slider.style.transform = `translateX(-${index * 100}%)`;
}

function prevSlide() {
    currentIndex = (currentIndex - 1 + slides.length) % slides.length;
    showSlide(currentIndex);
}

function nextSlide() {
    currentIndex = (currentIndex + 1) % slides.length;
    showSlide(currentIndex);
}
const messageElement = document.getElementById('message');


  function getCookie(name) {
    const cookieValue = document.cookie.match(`(^|;)\\s*${name}\\s*=\\s*([^;]+)`);
    return cookieValue ? decodeURIComponent(cookieValue[2]) : null;
  }
  
  // Retrieve the token from the cookie
  const savedToken = getCookie("token");
  
  if (savedToken) {
    console.log("Token found in cookie:", savedToken);
  } else {
    console.log("No token found in cookie.");
  }
  //register logic
  
  function clearAuthTokenCookie() {
    document.cookie = 'authToken=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
  }

  function logout() {
    clearAuthTokenCookie();
    window.location.href = 'index1.html'; 
  }
  
  //document.getElementById('logout').addEventListener('click', logout);

  
  const popupContainer = document.getElementById("popupContainer");
  const successPopup = document.getElementById("successPopup");
  const registerButton = document.getElementById("registerButton");
  const loginButton = document.getElementById("loginButton");
  const closeButton = document.getElementById("closeButton");

  registerButton.addEventListener("click", () => showPopup());
  loginButton.addEventListener("click", () => showPopup());
  closeButton.addEventListener("click", () => hidePopup());

document.addEventListener('DOMContentLoaded', () => {
  loadAllBooks();
});

function filterProductsByTitle() {
  const searchInput = document.getElementById('searchInput');
  const searchTerm = searchInput.value.toLowerCase();
  const productGallery = document.querySelector('.grid-container');
  const bookItems = productGallery.getElementsByClassName('book-item');

  for (const bookItem of bookItems) {
    const bookTitleElement = bookItem.querySelector('.book-title');
    const bookTitle = bookTitleElement.textContent.toLowerCase();

    if (bookTitle.includes(searchTerm)) {
      bookItem.style.display = 'block';
    } else {
      bookItem.style.display = 'none';
    }
  }
}

const bookGrid = document.getElementById('bookGrid');

fetch('https://localhost:44310/api/Book/allbooks')
    .then(response => response.json())
    .then(books => {
        books.forEach(book => {
            const bookElement = document.createElement('div');
            bookElement.classList.add('book');

            const bookImage = document.createElement('img');
            bookImage.src = book.bookImage;
            bookImage.alt = book.bookTitle;

            const bookInfo = document.createElement('div');
            bookInfo.classList.add('book-info');

            const bookTitle = document.createElement('div');
            bookTitle.classList.add('book-title');
            bookTitle.textContent = book.bookTitle;

            const bookAuthor = document.createElement('div');
            bookAuthor.classList.add('book-author');
            bookAuthor.textContent = book.bookAuthor;

            const addToCartButton = document.createElement('button');
            addToCartButton.classList.add('add-to-cart');
            addToCartButton.textContent = 'Add to Cart';

            addToCartButton.addEventListener("click", () => {
              addToCart(book);
            });
            const savedToken = localStorage.getItem("token");

            if (savedToken) {
              console.log("Token retrieved from local storage on the other page:", savedToken);
            } else {
              console.log("No token found in local storage on the other page.");
            }
            bookInfo.appendChild(bookTitle);
            bookInfo.appendChild(bookAuthor);
            bookInfo.appendChild(addToCartButton);

            bookElement.appendChild(bookImage);
            bookElement.appendChild(bookInfo);

            bookGrid.appendChild(bookElement);
        });
    })
    .catch(error => {
        console.error('Error fetching books:', error);
    });
    const token = getCookie("sessionToken");
    console.log(token);
    function addToCart(book) {
      const addToCartUrl = "https://localhost:44310/api/Bag/addtobag";

      const cartData = {
          bookTitle: book.title,
          bookAuthor: book.author,
          bookImage: book.coverImageUrl
      };

      fetch(addToCartUrl, {
          method: "POST",
          headers: {
              "Content-Type": "application/json",
              Authorization: `Bearer ${token}`
          },
          body: JSON.stringify(cartData)
      })
      .then(response => response.json())
      .then(data => {
          console.log("Book added to cart:", data);
      })
      .catch(error => {
          console.error("Error adding to cart:", error);
      });
    }

  // Function to get cookie value
  function getCookie(name) {
      const value = `; ${document.cookie}`;
      const parts = value.split(`; ${name}=`);
      if (parts.length === 2) return parts.pop().split(";").shift();
  }
  fetch('https://localhost:44310/api/Bag/getallbooks', {
  headers: {
    'Authorization': `Bearer ${token}`
  }
})
.then(response => response.json())
.then(cartData => {
  const table = document.getElementById('cart-items');

  cartData.forEach(item => {
    const row = table.insertRow();
    
    const titleCell = row.insertCell(0);
    const authorCell = row.insertCell(1);
    const imageCell = row.insertCell(2);

    titleCell.innerHTML = item.title;
    authorCell.innerHTML = item.author;

    // Assuming each item has an image URL
    const imageElement = document.createElement('img');
    imageElement.src = item.imageURL;
    imageElement.alt = item.title;
    imageCell.appendChild(imageElement);
  });
})
.catch(error => {
  console.error('Error fetching cart data:', error);
});

// Function to fetch all books and populate the grid
async function loadAllBooks() {
  const productGallery = document.getElementById('bookGrid');
  productGallery.innerHTML = '';

  try {
    const response = await fetch('https://localhost:44310/api/Book/allbooks');
    const books = await response.json();

    books.forEach(book => {
      const productItem = createProductItem(book);
      productGallery.appendChild(productItem);
    });
  } catch (error) {
    console.error('Error loading all books:', error);
  }
}

// Function to fetch books by category and populate the grid
async function loadBooksByCategory(categoryId) {
  const productGallery = document.querySelector('.grid-container');
  productGallery.innerHTML = '';

  try {
    const response = await fetch(`https://localhost:44310/api/Book/getbooksbycategory/${categoryId}?Id=${categoryId}`);
    const books = await response.json();

    books.forEach(book => {
      const productItem = createProductItem(book);
      productGallery.appendChild(productItem);
    });
  } catch (error) {
    console.error('Error loading books by category:', error);
  }
}

// Function to create a product item element
function createProductItem(book) {
  const productItem = document.createElement('div');
  productItem.classList.add('book-item');

  productItem.innerHTML = `
    <img class="book-image" src="${book.bookImage}" alt="${book.bookTitle}">
    <div class="book-info">
      <h3 class="book-title">${book.bookTitle}</h3>
      <p class="book-author">${book.bookAuthor}</p>
      <button class="add-to-cart" onclick="addToCart('${book.bookTitle}', '${book.bookAuthor}', '${book.bookImage}')">Add to Cart</button>
    </div>
  `;

  return productItem;
}

function handleCategoryChange() {
  const categorySelect = document.getElementById('categorySelect');
  const selectedCategoryId = categorySelect.value;

  if (selectedCategoryId === '1') {
    loadAllBooks();
  } else {
    loadBooksByCategory(selectedCategoryId);
  }
}

const categorySelect = document.getElementById('categorySelect');
categorySelect.addEventListener('change', handleCategoryChange);

const searchInput = document.getElementById('searchInput');
searchInput.addEventListener('keyup', filterProductsByTitle);

const sessionToken = getSessionToken('sessionToken');

//Adding to cart...
function addToCart(bookTitle, bookAuthor, bookImage){
  

if (!sessionToken) {
  alert('Session token not found.');
  return;
}

const bookDetails = {
    bookTitle: bookTitle,
    bookAuthor: bookAuthor,
    bookImage: bookImage,
};
0
// Make API request to add book to cart
fetch('/add-to-cart', {
    method: 'POST',
    headers: {
        'Authorization': sessionToken,
        'Content-Type': 'application/json',
    },
    body: JSON.stringify(bookDetails),
})
.then(response => response.json())
.then(data => {
    console.log(data.message);
})
.catch(error => {
    console.error('Error adding book to cart:', error);

});

}
const cartTableBody = document.querySelector('#cart-items tbody');

// Make API request to get cart items
fetch('https://localhost:44310/api/Bag/getallbooks', {
    method: 'GET',
    headers: {
        'Authorization': sessionToken,
    },
})
.then(response => response.json())
.then(cartItems => {
    // Populate the cart table with cart items
    cartItems.forEach(item => {
        const row = document.createElement('tr');
        
        const imageCell = document.createElement('td');
        const image = document.createElement('img');
        image.src = item.bookImage;
        image.alt = 'Book Image';
        imageCell.appendChild(image);
        
        const titleCell = document.createElement('td');
        titleCell.textContent = item.bookTitle;
        
        const authorCell = document.createElement('td');
        authorCell.textContent = item.bookAuthor;
        
        row.appendChild(imageCell);
        row.appendChild(titleCell);
        row.appendChild(authorCell);
        
        cartTableBody.appendChild(row);
    });
})
.catch(error => {
    console.error('Error fetching cart items:', error);
});



