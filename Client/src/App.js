import './App.css';
import { Route, Routes, Link, useNavigate } from 'react-router-dom';
import Books from './components/Books';
import Authors from './components/Authors';
import SignIn from './components/SignIn';
import Register from './components/Register';
import { isAuthenticated, getUserName, logout } from './helpers/authentication';
import { useEffect, useState } from 'react';
import AddBook from './components/AddBook';
import BookDetail from './components/BookDetail';
import EditBook from './components/EditBook';
import AuthorDetail from './components/AuthorDetail';
import AddAuthor from './components/AddAuthor';
import EditAuthor from './components/EditAuthor';

function App() {
  const [username, setUserName] = useState("");
  const navigate = useNavigate();
  const hasLoggedIn = isAuthenticated();
  const logOut = () => {
    setUserName("");
    logout();
    navigate('/');
  }
  useEffect(() => {
    
  },[username])
  return (
    <div className="App">
      <nav className="navbar navbar-expand-lg navbar-light bg-light container">
        <div className="container-fluid">
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <Link className="nav-link" to='/'>Books</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to='authors'>Authors</Link>
              </li>
            </ul>
            <div>
              <ul className="navbar-nav ml-auto">
                {hasLoggedIn && <li className="nav-link text-dark">logged in as {getUserName()}</li>}
                {hasLoggedIn && <li type="button" className="nav-link text-dark" onClick={logOut}>Log out</li>}
                {!hasLoggedIn && <Link className="nav-link" to='login'>Log in</Link>}
              </ul>
            </div>
          </div>
        </div>
      </nav>
      <Routes>
        <Route path="/" element={<Books />} />
        <Route path="authors" element={<Authors />} />
        <Route path="addAuthor" element={<AddAuthor />}/>
        <Route path="/authors/:id" element={<AuthorDetail />} />
        <Route path="/authors/edit/:id" element={<EditAuthor />} />
        <Route path="login" element={<SignIn setUserName={setUserName}/>} />
        <Route path="register" element={<Register />} />
        <Route path="addBook" element={<AddBook />}/>
        <Route path="/books/:id" element={<BookDetail />}/>
        <Route path="/books/edit/:id" element={<EditBook />}/>
      </Routes>
    </div>
  );
}

export default App;
