import { isExpired } from "react-jwt";
import { baseApiUrl } from "./globals";

const url = `${baseApiUrl}Authentication/`;

const isAuthenticated = () => {
    let token = localStorage.getItem("jwt");
    if (token && !isExpired(token)) {
        return true;
    } else {
        return false;
    }
}

const getUserName = () => {
    let jwt = localStorage.getItem('jwt');
    const userNameClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
    if (jwt != null) {
        let decodedJWT = JSON.parse(window.atob(jwt.split('.')[1]));
        return decodedJWT[userNameClaim];
    }
    return '';
}

const login = (user) => {
    return fetch(`${url}login`, {
        method: "POST",
        body: JSON.stringify(user),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })
}

const register = (user) => {
    return fetch(`${url}register`, {
        method: "POST",
        body: JSON.stringify(user),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    });
}

const logout = () => {
    localStorage.removeItem("jwt");
    localStorage.removeItem("userName");
}

export { isAuthenticated, getUserName, login, register, logout }