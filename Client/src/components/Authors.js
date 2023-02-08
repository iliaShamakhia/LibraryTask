import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getAuthors } from "../helpers/authors";
import { isAuthenticated } from "../helpers/authentication";

function Authors() {
  const [authors, setAuthors] = useState([]);
  const [filtered, setFiltered] = useState([]);
  const [search, setSearch] = useState("");
  const hasLoggedIn = isAuthenticated();

  useEffect(() => {
    getAuthors().then(res => res.json())
      .then(data => { setAuthors(data); setFiltered(data); }).catch(err => console.log(err));
      
  }, []);

  const searchAuthors = (e) => {
    let val = e.target.value;
    setSearch(val);
    let filteredAuthors = authors.filter(a => a.name?.toLowerCase().includes(val.toLowerCase()) || a.surname?.toLowerCase().includes(val.toLowerCase()));
    setFiltered(filteredAuthors);
  }

  return (
    <div className="container">
      <div className="container bg-dark">
        <h2 className="text-light">Authors</h2>
      </div>
      {hasLoggedIn && <div className="container bg-dark">
        <Link className="btn btn-success mt-1 mb-1" to='/addAuthor'>Add Author</Link>
      </div>}
      <div className="input-group mb-3 ">
        <div className="input-group-prepend">
          <span className="input-group-text" id="basic-addon1">Search</span>
        </div>
        <input type="text" className="form-control" placeholder="Search Author" value={search} onChange={searchAuthors}></input>
      </div>
      {filtered.map(a => <div key={a.id} className="mb-3"><Link key={a.id} to={`/authors/${a.id}`} state={a}>{a.name} {a.surname}</Link></div>)}
    </div>
  );
}

export default Authors;