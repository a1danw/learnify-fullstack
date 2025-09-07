import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from "./pages/Homepage";
import LoginPage from "./pages/Loginpage";
import DetailPage from "./pages/DetailPage";
import Navigation from "./components/Navigation";
import Categories from "./components/Categories";
import CategoryPage from "./pages/CategoryPage";
import DescriptionPage from "./pages/DescriptionPage";

function App() {
  return (
    <div className="App">
      <Router>
        <Navigation />
        <Categories />
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/category/:id" element={<CategoryPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/detail" element={<DetailPage />} />
          <Route path="/course/:id" element={<DescriptionPage />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
