import { useState } from 'react';
import axios from 'axios';
import "./LoginForm.scss";

const API_URL = "http://localhost:5046";

export default function LoginForm(){
    const [showSignup, setShowSignup] = useState(window.location.pathname === "/signup");

    const toggleForm = (evt) => {
        evt.preventDefault();
        setShowSignup(prev => !prev);
    }

    const submitForm = async (evt) => {
        evt.preventDefault();
        const username = document.querySelector("input#username").value;
        const password = document.querySelector("input#password").value;
        console.log(API_URL);

        axios.get(`${API_URL}/Player/login?username=${username}&password=${password}`).
            then(res => {
            const {data} = res;
            console.log(data);
        }).catch(err => {
            console.log(err.request.response);
        });
    }

    return (
        <form className="LoginForm">
            <h1> Login </h1>
            <div className="LoginForm-inputGroups">
                <div className="inputGroup"> 
                    <label>Username</label>
                    <input id="username" type="text" name="username" placeholder="JohnDoe"/>
                </div>
                { showSignup &&
                    <div className="inputGroup">
                        <label>Email</label>
                        <input id="email" type="email" name="email" />
                    </div>
                }
                <div className="inputGroup">
                    <label>Password</label>
                    <input id="password" type="password" name="password" /> 
                    { showSignup &&
                        <ul>
                            <li className="requirement"> Password sizes is 8 to 20 characters long </li>
                            <li className="requirement"> Contain at least one number </li>
                            <li className="requirement"> Contain at least one uppercase character </li>
                            <li className="requirement"> Contain only alphanumeric characters </li>
                        </ul>
                    }
                </div>
                { showSignup &&
                    <div className="inputGroup">
                        <label>Confirm Password</label>
                        <input id="passwordConfirm" type="password" name="passwordconfirm" />
                    </div>
                }
            </div>
            <button className="callToAction" onClick={submitForm} > {showSignup ? "Create Account" : "Enter"} </button>
            or
            <button className="secondary" onClick={toggleForm}> {showSignup ? "Log into an existing account" : "Create and Account"}</button> 
        </form>
    );
}
