import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getAuthors } from "../helpers/authors";

function Authors() {
  const [authors, setAuthors] = useState([]);

  useEffect(() => {
    getAuthors().then(res => res.json())
      .then(data => setAuthors(data)).catch(err => console.log(err));
  }, []);

  return (
    <div className="container">
      <div className="container bg-dark">
        <Link className="btn btn-success mt-1 mb-1" to='/addAuthor'>Add Author</Link>
      </div>
      {authors.map(a => <div key={a.id} className="mb-3"><Link key={a.id} to={`/authors/${a.id}`} state={a}>{a.name} {a.surname}</Link></div>)}
    </div>
  );
}

export default Authors;