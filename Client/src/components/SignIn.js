import { useState } from 'react';
import {Link} from 'react-router-dom';

function SignIn() {
    const [user, setUser] = useState({username : "", password : ""});

    const handleChange = (e) => {
        setUser(prev => {
            return {
                ...prev, [e.target.name] : e.target.value
            }
        });
    }

    const handleSubmit = () => {
        
    }

    return (
        <div className="container w-25">
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label htmlFor="username" className="form-label">Username</label>
                    <input type="text" name='username' className="form-control" id="username" value={user.username} onChange={e => handleChange(e)}></input>
                </div>
                <div className="mb-3">
                    <label htmlFor="password" className="form-label">Password</label>
                    <input type="password" name='password' className="form-control" id="password" value={user.password} onChange={e => handleChange(e)}></input>
                </div>
                <button type="submit" className="btn btn-primary">Log In</button>
            </form>
            <div className="mt-3">Don't have an account? <Link className="nav-link" to='/register'>Register</Link></div>
        </div>
    );
}

export default SignIn;