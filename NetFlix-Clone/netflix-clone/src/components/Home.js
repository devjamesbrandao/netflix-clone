import styled from "styled-components";
import ImgSlider from "./ImgSlider";
import Videos from "./Viewer";
import Recommends from "./Recommends";
import { useEffect, useState } from "react";
import axios from "axios";
import { useDispatch, useSelector } from "react-redux";
import { setMovies } from "../features/movieSlice";

const Home = (props) => {

  const dispatch = useDispatch();
  let recommends = [];
  let newDisneys = [];
  let originals = [];
  let trending = [];
  let sliders = [];

  const baseURL = "http://localhost:5146";

  useEffect(() => {
    let res = [];

    async function obterSliders(){
      res = await axios.get(`${baseURL}/sliders`);

      dispatch(
        setMovies({
          recommend: recommends,
          newDisney: newDisneys,
          original: originals,
          trending: trending,
          sliders: res.data
        })
      );
    }

    obterSliders();

  }, [])

  return (
    <Container>
      <ImgSlider />
      <Videos />
      <Recommends />
      {/* <NewDisney />
      <Originals />
      <Trending /> */}
    </Container>
  );
};

const Container = styled.main`
  position: relative;
  min-height: calc(100vh - 250px);
  overflow-x: hidden;
  display: block;
  top: 72px;
  padding: 0 calc(3.5vw + 5px);
  &:after {
    background: url("/images/home-background.png") center center / cover
      no-repeat fixed;
    content: "";
    position: absolute;
    inset: 0px;
    opacity: 1;
    z-index: -1;
  }
`;

export default Home;