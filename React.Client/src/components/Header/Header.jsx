import { NavLink } from "react-router-dom";
import "./Header.css";

export default function Header() {
    return (
        <header className="header">
            <div className="logo">
                React 19
            </div>

            <nav>
                <NavLink to="/">Home</NavLink>

                <NavLink to="/about">About</NavLink>

                <NavLink to="/contact">Contact</NavLink>
            </nav>
        </header>
    );
}