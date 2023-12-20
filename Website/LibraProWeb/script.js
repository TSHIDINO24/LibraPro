function registerUser() {
  const registrationForm = document.getElementById('registration-form');
  const formData = new FormData(registrationForm);
  const userData = {};
  formData.forEach((value, key) => {
    userData[key] = value;
  });

  // Perform the POST request to register the user
  fetch('https://funsagewave55.conveyor.cloud/api/User/userregister', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(userData),
  })
  .then(response => response.json())
  .then(data => {
    console.log(data);
    if (data.success) {
      alert('User registered successfully!');
      // window.location.href = '/login.html';
    } else {
      alert('Registration failed. Please try again.');
    }
  })
  .catch(error => {
    console.error('Error:', error);
    alert('Registration failed. Please try again.');
  });
}


// Function to add items to the cart and store them in sessionStorage
function addToCart() {
 
}

// Function to remove an item from the cart
function removeFromCart(index) {
  let cartItems = sessionStorage.getItem('cartItems');
  if (!cartItems) {
    return;
  }

  cartItems = JSON.parse(cartItems);

  if (index >= 0 && index < cartItems.length) {
    cartItems.splice(index, 1);
    sessionStorage.setItem('cartItems', JSON.stringify(cartItems));
    displayCartItems();
    updateCartIcon();
  }
}

// Function to clear the cart
function clearCart() {
  sessionStorage.removeItem('cartItems');
  displayCartItems();
  updateCartIcon();
}

// Function to update the cart icon in the header
function updateCartIcon() {
  let cartItems = sessionStorage.getItem('cartItems');
  if (!cartItems) {
    cartItems = [];
  } else {
    cartItems = JSON.parse(cartItems);
  }

  const cartIcon = document.getElementById('cart-icon');
}

function displayCartItems() {
  let cartItems = sessionStorage.getItem('cartItems');
  if (!cartItems) {
    cartItems = [];
  } else {
    cartItems = JSON.parse(cartItems);
  }

  const cartItemsTable = document.querySelector('.cart-items tbody');
  cartItemsTable.innerHTML = '';

  cartItems.forEach((item, index) => {
    const row = document.createElement('tr');
    row.innerHTML = `
      <td>${item.image}</td>
      <td>$${item.title}</td>
      <td>${item.quantity}</td>
      <td>
        <button onclick="removeFromCart(${index})">Remove</button>
      </td>
    `;
    cartItemsTable.appendChild(row);
  });
}

function loadProducts() {
  const productGallery = document.querySelector('.product-gallery');
  productGallery.innerHTML = '';

  fetch('https://littletanbike28.conveyor.cloud/api/Book/allbooks')
    .then(response => response.json())
    .then(data => {
      data.forEach(product => {
        const productItem = document.createElement('div');
        productItem.classList.add('product-item');

        productItem.innerHTML = `
          <img class="product-image" src="${product.image}" alt="${product.title}">
          <h3 class="product-name">${product.title}</h3>
          <button onclick="addToCart('${product.image}', ${product.price})">Add to Cart</button>
        `;

        productGallery.appendChild(productItem);
      });
    })
    .catch(error => {
      console.error('Error loading products:', error);
    });
}

// Function to go to the cart page
function goToCart() {
  window.location.href = 'cart.html';
}

window.addEventListener('DOMContentLoaded', () => {
  loadProducts();
});

function filterProductsByName() {
  const searchInput = document.getElementById("search-input");
  const filterValue = searchInput.value.trim().toLowerCase();

  const productGallery = document.getElementById("product-gallery");
  const productItems = productGallery.getElementsByClassName("product-item");

  for (const item of productItems) {
    const itemName = item.getElementsByClassName("product-name")[0].innerText.toLowerCase();

    if (itemName.includes(filterValue)) {
      item.style.display = "block";
    } else {
      item.style.display = "none";
    }
  }
}
const searchInput = document.getElementById("search-input");
searchInput.addEventListener("keyup", filterProductsByName);