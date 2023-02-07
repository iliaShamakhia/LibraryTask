import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { addBook } from "../helpers/books";
import DatePicker from 'react-date-picker';

function AddBook() {
    const navigate = useNavigate();
    const [book, setBook] = useState({
        title: "",
        description: "",
        imageUrl: "",
        rating: 0.0,
        publishDate: new Date(),
        isAvailable: true,
        authors: []
    });
    const [author, setAuthor] = useState({ name: "", surname: "", birthYear: new Date() })

    const handleChange = (e) => {
        let { name, value, type, checked } = e.target;
        setBook(prev => {
            return {
                ...prev, [name]: type === "checkbox" ? checked : value
            }
        })
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        addBook(book)
        .then(() => navigate('/'))
        .catch(err => console.log(err));
    }

    const handleDateChange = (val) => {
        setBook(prev => {
            return {
                ...prev, publishDate: val
            }
        })
    }
    const handleAuthorDateChange = (val) => {
        setAuthor(prev => {
            return {
                ...prev, birthYear: val
            }
        })
    }

    const addAuthor = (e) => {
        e.preventDefault();
        let authorsNew = [...book.authors];
        authorsNew.push(author);
        setBook(prev => {
            return {
                ...prev, authors: authorsNew
            }
        });
        setAuthor({
            name: "",
            surname: "",
            birthYear: new Date()
        });
    }

    const handleAuthorChange = (e) => {
        setAuthor(prev => {
            return {
                ...prev, [e.target.name]: e.target.value
            }
        })
    }

    return (
        <div className="container w-25">
            <form onSubmit={(e) => handleSubmit(e)}>
                <div className="mb-3">
                    <label htmlFor="title" className="form-label">Title</label>
                    <input type="text" name='title' className="form-control" id="title" value={book.title} onChange={e => handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="description" className="form-label">Description</label>
                    <input type="text" name='description' className="form-control" id="description" value={book.description} onChange={e => handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="imageUrl" className="form-label">Image Url</label>
                    <input type="text" name='imageUrl' className="form-control" id="imageUrl" value={book.imageUrl} onChange={e => handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="isAvailable" className="form-label">Is Available:</label>
                    <input type="checkbox" checked={book.isAvailable} name='isAvailable' className="m-2 mt-5" id="isAvailable" value={book.isAvailable} onChange={e => handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="rating" className="form-label">Rating</label>
                    <input type="number" name="rating" id="rating" className="form-control"
                        value={book.rating}
                        min="0.0"
                        step="0.1"
                        max="5.0"
                        presicion={2}
                        onChange={(e) => handleChange(e)} />
                </div>
                <div className="mb-3">
                    <label htmlFor="publishDate" className="form-label">Publish Date</label>
                    <DatePicker onChange={(val) => handleDateChange(val)} value={book.publishDate} />
                </div>
                <div className="mb-3">
                    Add Author
                </div>
                <div className="author-box mb-3">
                    <div className="mb-3">
                        <label htmlFor="name" className="form-label">Name</label>
                        <input type="text" name='name' className="form-control" id="name" value={author.name} onChange={e => handleAuthorChange(e)}></input>
                    </div>
                    <div className="mb-3">
                        <label htmlFor="surname" className="form-label">Surname</label>
                        <input type="text" name='surname' className="form-control" id="surname" value={author.surname} onChange={e => handleAuthorChange(e)}></input>
                    </div>
                    <div className="mb-3">
                        <label htmlFor="birthYear" className="form-label">Date of Birth</label>
                        <DatePicker onChange={(val) => handleAuthorDateChange(val)} value={author.birthYear} />
                    </div>
                    <button onClick={addAuthor} className="btn btn-primary mb-2">Add Author</button>
                </div>
                <button type="submit" className="btn btn-primary">Add Book</button>
            </form>
        </div>
    );
}

export default AddBook;