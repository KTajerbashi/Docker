import { Routes, Route } from "react-router-dom";
import Layout from "../components/Layouts/Layout";

import Home from "../pages/Home/Home";
import About from "../pages/About/About";
import Contact from "../pages/Contact/Contact";

export default function AppRoutes() {
    return (
        <Routes>
            <Route element={<Layout />}>
                <Route index element={<Home />} />
                <Route path="/about" element={<About />} />
                <Route path="/contact" element={<Contact />} />
            </Route>
        </Routes>
    );
}