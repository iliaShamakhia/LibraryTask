import { useState, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { editAuthor } from "../helpers/authors";
import DatePicker from 'react-date-picker';

function EditAuthor(){
    const location = useLocation();
    const navigate = useNavigate();
    const [author, setAuthor] = useState({name:"",surname:"",birthYear:new Date()});

    useEffect(() => {
        setAuthor(location.state);
    }, []);

    const handleSubmit = (e) => {
        e.preventDefault();
        editAuthor(author).then(() => navigate('/authors')).catch(err => console.log(err));
    }

    const handleChange = (e) => {
        let { name, value } = e.target;
        setAuthor(prev => {
            return {
                ...prev, [name]: value
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

    return (
        <div className="container w-25">
            <form onSubmit={(e) => handleSubmit(e)}>
                <div className="mb-3">
                    <label htmlFor="name" className="form-label">Name</label>
                    <input type="text" name='name' className="form-control" id="name" value={author.name} onChange={e => handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="surname" className="form-label">Surname</label>
                    <input type="text" name='surname' className="form-control" id="surname" value={author.surname} onChange={e => handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="birthYear" className="form-label">Date of Birth</label>
                    <DatePicker onChange={(val) => handleAuthorDateChange(val)} value={author.birthYear} />
                </div>
                <button type="submit" className="btn btn-primary">Add Author</button>
            </form>
        </div>
    );
}

export default EditAuthor;