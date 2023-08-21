async function getUsers() {
    const response = await fetch('/api/users');
    const data = await response.json();
    const usersDiv = document.getElementById('users');
    usersDiv.innerHTML = `<h2>All Users</h2><ul>${data.map(user => `<li>${user}</li>`).join('')}</ul>`;
}

async function getUser(id) {
    const response = await fetch(`/api/users/${id}`);
    if (response.status === 200) {
        const user = await response.text();
        const userDiv = document.getElementById('user');
        userDiv.innerHTML = `<h2>User</h2><p>${user}</p>`;
    } else {
        const userDiv = document.getElementById('user');
        userDiv.innerHTML = `<h2>User not found</h2>`;
    }
}

document.addEventListener('DOMContentLoaded', () => {
    getUsers();
    getUser(1); 
});
