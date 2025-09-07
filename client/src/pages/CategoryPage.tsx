import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import agent from "../actions/agent";
import { Row } from "antd";
import { Category } from "../models/category";
import Courses from "../components/Courses";
import { Course } from "../models/course";

const CategoryPage = () => {
  const [data, setData] = useState<Category>();
  const { id } = useParams<{ id: string }>();

  useEffect(() => {
    agent.Categories.getCategory(parseInt(id)).then((response) => {
      setData(response);
    });
  }, [id]);

  return (
    <div className="course">
      <div className="course__header">
        <h1>Pick a course from your favourite Category</h1>
        <h2>{data?.name}</h2>
      </div>
      <Row gutter={[24, 32]}>
        {data?.courses && data.courses.length > 0 ? (
          data.courses.map((course: Course, index: number) => (
            <Courses key={index} course={course} index={index} />
          ))
        ) : (
          <h1>There are no courses available in this category.</h1>
        )}
      </Row>
    </div>
  );
};

export default CategoryPage;
