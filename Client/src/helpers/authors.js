import { baseApiUrl } from "./globals";

const url = `${baseApiUrl}Authors/`;

const getAuthors = () => {
    return fetch(url);
}

const addAuthor = (author) => {
    return fetch(url, {
        method: "POST",
        body: JSON.stringify(author),
        headers: {
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`,
            "Content-type": "application/json; charset=UTF-8"
        }
    });
}

const editAuthor = (author) => {
    return fetch(`${url}${author.id}`, {
        method: "PUT",
        body: JSON.stringify(author),
        headers: {
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`,
            "Content-type": "application/json; charset=UTF-8"
        }
    });
}

const deleteAuthor = (id) => {
    return fetch(`${url}${id}`, {
        method: "DELETE",
        headers: {
            'Authorization': `Bearer ${localStorage.getItem("jwt")}`,
            "Content-type": "application/json; charset=UTF-8"
        }
    });
}

export { getAuthors, addAuthor, editAuthor, deleteAuthor }