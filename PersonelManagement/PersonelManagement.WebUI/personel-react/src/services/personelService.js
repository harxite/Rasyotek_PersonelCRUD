import axios from "axios";

const PERSONEL_API_URL = "https://localhost:7113/api/personel"; // API address for personel
const UNIVERSITIES_API_URL =
  "http://universities.hipolabs.com/search?country=Turkey"; // API address for universities

// Personel API functions
export const getPersonellers = () => axios.get(PERSONEL_API_URL);
export const getPersonel = (id) => axios.get(`${PERSONEL_API_URL}/${id}`);
export const createPersonel = (personel) =>
  axios.post(PERSONEL_API_URL, personel);
export const updatePersonel = (id, personel) =>
  axios.put(`${PERSONEL_API_URL}/${id}`, personel);
export const deletePersonel = (id) => axios.delete(`${PERSONEL_API_URL}/${id}`);

// Universities API functions
export const getUniversities = () => axios.get(UNIVERSITIES_API_URL);
