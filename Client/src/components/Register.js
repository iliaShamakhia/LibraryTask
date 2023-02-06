import{ useState } from 'react';
import { register } from '../helpers/authentication';
import { useNavigate } from 'react-router-dom';

function Register() {
    const navigate = useNavigate();
    const [user,setUser] = useState({
            firstName : "",
            lastName : "",
            username : "",
            email : "",
            password : ""
    });

    const handleChange = (e) => {
        setUser(prev => {
            return {
                ...prev, [e.target.name] : e.target.value
            }
        })
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        register(user).then(() => navigate('/login')).catch(err => console.log(err));
    }

    return (
        <div className="container w-25">
            <form onSubmit={(e) => handleSubmit(e)}>
                <div className="mb-3">
                    <label htmlFor="firstname" className="form-label">First Name</label>
                    <input type="text" name='firstName' className="form-control" id="firstname" value={user.firstName} onChange={e =>handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="lastname" className="form-label">Last Name</label>
                    <input type="text" name='lastName' className="form-control" id="lastname" value={user.lastName} onChange={e =>handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="username" className="form-label">Username</label>
                    <input type="text" name='username' className="form-control" id="username" value={user.username} onChange={e =>handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="email" className="form-label">E-mail</label>
                    <input type="email" name='email' className="form-control" id="email" value={user.email} onChange={e =>handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="password" className="form-label">Password</label>
                    <input type="password" name='password' className="form-control" id="password" value={user.password} onChange={e => handleChange(e)}></input>
                </div>
                <button type="submit" className="btn btn-primary">Register</button>
            </form>
        </div>
    );
  }
  
  export default Register;