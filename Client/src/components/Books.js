import { useEffect, useState } from "react";
import { getBooks } from "../helpers/books";
import { Link } from "react-router-dom";

function Books() {
  const [books, setBooks] = useState([]);

  useEffect(() => {
    getBooks().then(res => res.json()).then(data => setBooks(data)).catch(err => console.log(err));
  }, []);

  return (
    <div className="container bg-light">
      <div className="container bg-dark">
        <h2 className="text-light">Books</h2>
      </div>
      <div className="container bg-dark">
        <Link className="btn btn-success mt-1 mb-1" to='addBook'>Add Book</Link>
      </div>
      {books.map(b => <div className="cards" key={b.id}>
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