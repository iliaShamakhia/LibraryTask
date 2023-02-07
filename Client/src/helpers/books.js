import { baseApiUrl } from "./globals";

const url = `${baseApiUrl}Books/`;

const getBooks = () => {
    return fetch(url);
}

const getSingleBook = (id) => {
    return fetch(`${url}id`);
}

const addBook = (book) => {
    return fetch(url, {
        method: "POST",
        body: JSON.stringify(book),
        headers: {
            /* 'Authorization': `Bearer ${localStorage.getItem("jwt")}`, */
            "Content-type": "application/json; charset=UTF-8"
        }
    });
}

export { getBooks, getSingleBook, addBook }