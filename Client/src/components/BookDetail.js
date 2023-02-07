import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { deleteBook } from "../helpers/books";
import { useNavigate, Link } from "react-router-dom";
import { editBook } from "../helpers/books";


function BookDetail() {
    const location = useLocation();
    const [book, setBook] = useState({});
    const navigate = useNavigate();

    useEffect(() => {
        setBook(location.state);
    }, []);

    const takeBook = (e) => {
        e.preventDefault();
        setBook(prev => {
            return {
                ...prev,
                isAvailable : false
            }
        });
        editBook(book).then(() => console.log()).catch(err => console.log(err));
    }

    const delBook = (e) => {
        e.preventDefault();
        deleteBook(book.id).then(() => navigate('/')).catch(err => console.log(err));
    }

    return (
        <div className="container">
            <div className="card">
                <h5 className="card-header">{book.title}</h5>
                <div className="card-container">
                    <div className="imgBox">
                        <img className="card-img-top" src={book.imageUrl} alt="book-cover"></img>
                    </div>
                    <div className="card-body">
                        <h5 className="card-title">{book.authors?.map(a => `${a.name} ${a.surname}`).join(' ')}</h5>
                        <p className="card-text">{book.description}</p>
                        <p className="card-text">Rating: {book.rating}</p>
                        <p className="card-text">Date Published: {book.publishDate?.substring(0,10)}</p>
                        <p className="card-text">Is Available: {book.isAvailable?"Yes": "No"}</p>
                        <div>
                            <button type="button" className="btn btn-success m-2" onClick={takeBook}>Take</button>
                            <Link to={`/books/edit/${book.id}`} className="btn btn-success m-2" state={book}>Edit</Link>
                            <button type="button" className="btn btn-danger m-2" onClick={delBook}>Delete</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default BookDetail;