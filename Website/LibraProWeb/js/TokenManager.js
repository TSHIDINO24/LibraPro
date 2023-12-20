
// Save the token
function saveToken(token) {
    localStorage.setItem("token", token);
  }
  
  // Retrieve the token
  function getToken() {
    return localStorage.getItem("token");
  }
  
  // Delete the token
  function deleteToken() {
    localStorage.removeItem("token");
  }
  
  