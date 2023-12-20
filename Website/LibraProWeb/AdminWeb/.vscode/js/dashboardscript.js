const allSideMenu = document.querySelectorAll('#sidebar .side-menu.top li a');

allSideMenu.forEach(item=> {
	const li = item.parentElement;

	item.addEventListener('click', function () {
		allSideMenu.forEach(i=> {
			i.parentElement.classList.remove('active');
		})
		li.classList.add('active');
	})
});

///////////////////////////////////////////////////////// TOGGLE SIDEBAR
const menuBar = document.querySelector('#content nav .bx.bx-menu');
const sidebar = document.getElementById('sidebar');

menuBar.addEventListener('click', function () {
	sidebar.classList.toggle('hide');
})

const searchButton = document.querySelector('#content nav form .form-input button');
const searchButtonIcon = document.querySelector('#content nav form .form-input button .bx');
const searchForm = document.querySelector('#content nav form');

searchButton.addEventListener('click', function (e) {
	if(window.innerWidth < 576) {
		e.preventDefault();
		searchForm.classList.toggle('show');
		if(searchForm.classList.contains('show')) {
			searchButtonIcon.classList.replace('bx-search', 'bx-x');
		} else {
			searchButtonIcon.classList.replace('bx-x', 'bx-search');
		}
	}
})

if(window.innerWidth < 768) {
	sidebar.classList.add('hide');
} else if(window.innerWidth > 576) {
	searchButtonIcon.classList.replace('bx-x', 'bx-search');
	searchForm.classList.remove('show');
}

window.addEventListener('resize', function () {
	if(this.innerWidth > 576) {
		searchButtonIcon.classList.replace('bx-x', 'bx-search');
		searchForm.classList.remove('show');
	}
})

const switchMode = document.getElementById('switch-mode');

switchMode.addEventListener('change', function () {
	if(this.checked) {
		document.body.classList.add('dark');
	} else {
		document.body.classList.remove('dark');
	}
})

document.addEventListener("DOMContentLoaded", function() {
  const sidebar = document.getElementById('#sidebar');
  sidebar.classList.add('active'); //  line to show the sidebar by default 
});










// Function to handle the "Edit" button click
function handleEditButtonClick() {
  var bookId = event.target.getAttribute("data-book-id");
  // Fetch book details from the API using bookId
  fetch('https://earlysagecar82.conveyor.cloud/api/Book/getbook /7' + bookId)
    .then(response => response.json())
    .then(bookData => {
      // Populate the form fields with fetched data
      //document.getElementById("id").value = bookData.bookId;
      document.getElementById("editTitle").value = bookData.bookTitle;
      document.getElementById("editAuthor").value = bookData.bookAuthor;
      document.getElementById("editDescription").value = bookData.bookDescription;
      //document.getElementById("quantity").value = bookData.Book_Quantity;
      document.getElementById("category").value = bookData.category;

      // Show the "Edit Book" form
      document.getElementById("editBookForm").style.display = "block";
    })
    .catch(error => {
      console.error("Error fetching book data:", error);
    });
}


// Event listener for the "Update Book" button click
document.getElementById("updateBookBtn").addEventListener("click", function () {
  const updatedBookData = {
    bookTitle: document.getElementById("editTitle").value,
    bookAuthor: document.getElementById("editAuthor").value,
    bookDescription: document.getElementById("editDescription").value,
    bookQuantity: parseInt(document.getElementById("editQuantity").value),
    category: document.getElementById("editCategory").value,
  };

  //API call to update book details
  fetch('https://lostbrasshouse7.conveyor.cloud/api/Book/edituser/${bookId}' , {
    method: 'PUT',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(updatedBookData),
  })
    .then(response => response.json())
    .then(updatedBook => {
      hideEditForm();
    })
    .catch(error => {
      console.error("Error updating book:", error);
    });
});

// Event listener for the "Cancel" button click
document.getElementById("cancelUpdateBtn").addEventListener("click", function () {
  hideEditForm();
});

// Event listener for the "Delete Book" button click
/*document.getElementById("deleteBookBtn").addEventListener("click", function () {
  const confirmation = confirm("Are you sure you want to delete this book?");

  if (confirmation) {
    //API call to delete the book
    fetch('https://lostbrasshouse7.conveyor.cloud/api/Book/deleteuser/7' + bookId, {
      method: 'DELETE',
    })
      .then(response => response.json())
      .then(deletedBook => {
      
        hideEditForm();
        
      })
      .catch(error => {
        console.error("Error deleting book:", error);
      });
  }
});
*/