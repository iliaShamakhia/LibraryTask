import { useState } from "react";
import { useLocation } from "react-router-dom";
import { deleteAuthor } from "../helpers/authors";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

function AuthorDetail(){
    const [author, setAuthor] = useState({name:"", surname:"", birthYear:new Date()});
    const location = useLocation();
    const navigate = useNavigate();

    setAuthor(location.state);

    const delAuthor = () => {
        deleteAuthor(author.id).then(() => navigate("/authors")).catch(err => console.log(err));
    }

    return (
        <div className="container">
            <div className="card">
                <h5 className="card-header">Author</h5>
                <div className="card-container">
                    <div className="card-body">
                        <h5 className="card-title">{author.name} {author.surname}</h5>
                        <p className="card-text">{author.birthYear?.substring(0,10)}</p>
                        <div>
                            <Link to={`/authors/edit/${author.id}`} className="btn btn-success m-2" state={author}>Edit</Link>
                            <button type="button" className="btn btn-danger m-2" onClick={delAuthor}>Delete</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default AuthorDetail;