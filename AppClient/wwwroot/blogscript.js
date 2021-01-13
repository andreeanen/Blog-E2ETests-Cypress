const addButton = document.getElementById('add-new-blogpost-button');
addButton.style.display = window.localStorage.getItem('userStatus') === '1' ? 'block' : 'none';

const endpoint = 'http://localhost:6001/api/Blogposts';

function getBlogPosts() {
    fetch(endpoint)
        .then(function (response) {
            console.log(response);
            if (response.ok) {
                return response.json();
            }
            else {
                console.log('Error');
            }
        })
        .then(function (data) {
            console.log(data);
            displayBlogs(data);
        })
        .catch(function (error) {
            console.error('Failed getting blogposts.', error);
        })
}

let blogList = [];
function displayBlogs(data) {
    const tBody = document.getElementById('blogposts');
    tBody.innerHTML = '';

    data.forEach(item => {
        let titleRow = tBody.insertRow();
        titleRow.className = "blogpost-row";
        let titleCell = titleRow.insertCell(0);
        let title = document.createTextNode(item.title);
        titleCell.appendChild(title);

        let creationRow = tBody.insertRow();
        let creationCell = creationRow.insertCell(0);
        let creation = document.createTextNode('Created by ' + item.author + ' on ' + item.dateTime);
        creationCell.appendChild(creation);

        let textRow = tBody.insertRow();
        let textCell = textRow.insertCell(0);
        let text = document.createTextNode(item.text);
        textCell.appendChild(text);
    });

    blogList = data;
}

function addNewBlogpost() {
    document.getElementById('author').value = window.localStorage.getItem('usernameLogedIn');

    var createForm = document.getElementById('create-blog-form');
    createForm.style.display = 'block';
}

function createBlogpost() {
    const body = {
        author: document.getElementById('author').value,
        title: document.getElementById('title').value,
        text: document.getElementById('text').value
    };
    const stringifiedBody = JSON.stringify(body);

    fetch(endpoint, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: stringifiedBody
    })
        .then(response => response.json)
        .then(data => console.info(data))
        .catch(error => console.error(error));

    closeBlogForm();
    getBlogPosts();
}

function closeBlogForm() {
    document.getElementById('title').value = null;
    document.getElementById('text').value = null;
    document.getElementById('create-blog-form').style.display = 'none';
}

getBlogPosts();