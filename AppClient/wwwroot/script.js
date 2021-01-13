function login() {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    const baseUrl = 'http://localhost:6002/api/Users?';
    const queryString = `username=${username}&password=${password}`;
    const endpoint = baseUrl + queryString;

    fetch(endpoint)
        .then(function (response) {
            if (response.ok) {
                return response.json();
            }
            else {
                document.getElementById('info').innerHTML = 'Username or password are incorrect. Try again'
            }
        })
        .then(function (data) {
           
            document.getElementById('info').innerHTML = `${data.username} is logged in.`;
            localStorage.setItem("usernameLogedIn", data.username);
            localStorage.setItem("userStatus", data.userStatus);
            location.href = "/blog.html";
        })
        .catch(function (error) {
            console.error('Unable to login.', error);
        })
}