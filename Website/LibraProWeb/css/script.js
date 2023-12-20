document.addEventListener('DOMContentLoaded', () => {
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
// Function to fetch all books and populate the grid
// Function to fetch all books and populate the grid
async function loadAllBooks() {
  const productGallery = document.querySelector('.grid');
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
  const productGallery = document.querySelector('.grid');
  productGallery.innerHTML = '';

  try {
    const response = await fetch(`https://localhost:44310/api/Book/getbooksbycategory?Id=${categoryId}`);
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
  productItem.classList.add('book');

  productItem.innerHTML = `
    <img src="${book.bookImage}" alt="${book.bookTitle}">
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
//searchInput.addEventListener('keyup', filterProductsByTitle);

loadAllBooks();




