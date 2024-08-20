import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import PersonelList from "./components/PersonelList";
import PersonelForm from "./components/PersonelForm";
import "bootstrap/dist/css/bootstrap.min.css";
import Navbar from "./components/Navbar";

const App = () => {
  return (
    <Router>
      <div>
        <Navbar />
        <Routes>
          <Route path="/" element={<PersonelList />} />
          <Route path="/add" element={<PersonelForm />} />
          <Route path="/edit/:id" element={<PersonelForm />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
