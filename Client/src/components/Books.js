import { useEffect, useState } from "react";
import { getBooks } from "../helpers/books";
import { Link } from "react-router-dom";
import { isAuthenticated } from "../helpers/authentication";

function Books() {
  const [books, setBooks] = useState([]);
  const [filtered, setFiltered] = useState([]);
  const [search, setSearch] = useState("");
  const hasLoggedIn = isAuthenticated();

  useEffect(() => {
    getBooks().then(res => res.json())
    .then(data => {setBooks(data); setFiltered(data);}).catch(err => console.log(err));
  }, []);

  const searchBooks = (e) => {
    let val = e.target.value;
    setSearch(val);
    let filteredBooks = books.filter(b => b.title?.toLowerCase().includes(val.toLowerCase()));
    setFiltered(filteredBooks);
  }

  return (
    <div className="container bg-light">
      <div className="container bg-dark">
        <h2 className="text-light">Books</h2>
      </div>
      {hasLoggedIn && <div className="container bg-dark">
        <Link className="btn btn-success mt-1 mb-1" to='addBook'>Add Book</Link>
      </div>}
      <div className="input-group mb-3 ">
        <div className="input-group-prepend">
          <span className="input-group-text" id="basic-addon1">Search</span>
        </div>
        <input type="text" className="form-control" placeholder="Search Book" value={search} onChange={searchBooks}></input>
      </div>
      {filtered.map(b => <div className="cards" key={b.id}>
        <div className="card">
          <Link className="card-header" to={`/books/${b.id}`} state={b}>{b.title}</Link>
          <div className="card-container">
            <div className="imgBox">
              <img className="card-img-top" src={b.imageUrl} alt="book-cover"></img>
            </div>
            <div className="card-body">
              <h5 className="card-title">{b.authors.map(a => `${a.name} ${a.surname}`).join(' ')}</h5>
              <p className="card-text">{b.description}</p>
            </div>
          </div>
        </div>
      </div>)}
    </div>
  );
}

export default Books;