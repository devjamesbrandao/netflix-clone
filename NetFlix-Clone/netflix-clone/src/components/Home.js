import styled from "styled-components";
import ImgSlider from "./ImgSlider";
import Videos from "./Viewer";
import Recommends from "./Recommends";
import NewDisney from "./NewDisney";
import Originals from "./Originals";
import Trending from "./Trendings";
import axios from "axios";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { setMovies } from "../features/movieSlice";

const Home = (props) => {

  const dispatch = useDispatch();
  
  const baseURL = "http://localhost:5146";

  useEffect(() => {
    let sliders = [];

    let midias = [];

    async function obterConteudo(){
      sliders = await axios.get(`${baseURL}/sliders`);

      midias = await axios.get(`${baseURL}/midias`);

      dispatch(
        setMovies({
          recommend: midias.data.filter(x => x.type === "recommend"),
          newDisney: midias.data.filter(x => x.type === "new"),
          original: midias.data.filter(x => x.type === "original"),
          trending: midias.data.filter(x => x.type === "trending"),
          sliders: sliders.data
        })
      );
    }

    obterConteudo();

  }, [])

  return (
    <Container>
      <ImgSlider />
      <Videos />
      <Recommends />
      <NewDisney />
      <Originals />
      <Trending /> 
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