import { isExpired } from "react-jwt";

const isAuthenticated = () => {
    let token = localStorage.getItem("jwt");
    if (token && !isExpired(token)) {
        return true;
    } else {
        return false;
    }
}

const getUsername = () => {
    let jwt = localStorage.getItem('jwt');
    const userNameClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
    if (jwt != null) {
        let decodedJWT = JSON.parse(window.atob(jwt.split('.')[1]));
        return decodedJWT[userNameClaim];
    }
    return '';
}

const login = (user) => {
    return;
}

const register = (user) => {
    return;
}

const logout = () => {
    localStorage.removeItem("jwt");
    localStorage.removeItem("fullName");
}

export { isAuthenticated, getUsername, login, register, logout }