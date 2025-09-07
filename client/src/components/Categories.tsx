import React, { useEffect, useState } from "react";
import agent from "../actions/agent";
import { Category } from "../models/category";
import { Link } from "react-router-dom";

const Categories = () => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    agent.Categories.list().then((response) => {
      setCategories(response);
    });
  }, []);

  return (
    <div className="categories">
      {categories &&
        categories.map((category: Category, index: number) => (
          <Link key={index} to={`/category/${category.id}`}>
            <div className="categories__name">{category.name}</div>
          </Link>
        ))}
    </div>
  );
};

export default Categories;
