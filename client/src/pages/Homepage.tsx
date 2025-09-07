import { useState, useEffect } from "react";
import agent from "../actions/agent"; // for api requests
import { PaginatedCourse } from "../models/paginatedCourse";
import Courses from "../components/Courses";
import { Row } from "antd";
import { Course } from "../models/course";

const HomePage = () => {
  const [data, setData] = useState<PaginatedCourse>();

  useEffect(() => {
    agent.Courses.list().then((response) => {
      setData(response);
    });
  }, []);

  return (
    <div className="course">
      <div className="course__header">
        <h1>What to Learn Next?</h1>
        <h2>New Courses picked just for you...</h2>
      </div>
      <Row gutter={[24, 32]}>
        {data &&
          data.data.map((course: Course, index: number) => {
            return <Courses key={index} course={course} index={index} />;
          })}
      </Row>
    </div>
  );
};

export default HomePage;
