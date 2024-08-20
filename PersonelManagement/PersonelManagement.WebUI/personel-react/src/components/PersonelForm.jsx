import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Select from "react-select";
import {
  createPersonel,
  updatePersonel,
  getPersonel,
  getUniversities,
} from "../services/personelService";

const debitOptions = [
  { label: "Araba", value: "Araba" },
  { label: "Laptop", value: "Laptop" },
  { label: "Tablet", value: "Tablet" },
  { label: "Telefon", value: "Telefon" },
];

const PersonelForm = () => {
  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    gender: "Erkek",
    debits: [],
    university: "",
  });
  const [universities, setUniversities] = useState([]);
  const navigate = useNavigate();
  const { id } = useParams();

  useEffect(() => {
    if (id) {
      fetchPersonel(id);
    }
    fetchUniversities();
  }, [id]);

  const fetchPersonel = async (id) => {
    try {
      const response = await getPersonel(id);
      setFormData({
        ...response.data,
        debits: response.data.debits.map((d) => ({ name: d.name })),
        gender: response.data.gender,
      });
    } catch (error) {
      console.error("Error fetching personel", error);
    }
  };

  const fetchUniversities = async () => {
    try {
      const response = await getUniversities();
      setUniversities(
        response.data.map((univ) => ({ value: univ.name, label: univ.name }))
      );
    } catch (error) {
      console.error("Error fetching universities", error);
    }
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSelectChange = (selectedOptions) => {
    setFormData({
      ...formData,
      debits: selectedOptions
        ? selectedOptions.map((opt) => ({ name: opt.value }))
        : [],
    });
  };

  const handleUniversityChange = (selectedOption) => {
    setFormData({
      ...formData,
      university: selectedOption ? selectedOption.value : "",
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!formData.firstName || !formData.lastName || !formData.university) {
      alert("Lütfen tüm alanları doldurun."); 
      return;
    }

    try {
      if (id) {
        await updatePersonel(id, formData);
      } else {
        await createPersonel(formData);
      }
      navigate("/");
    } catch (error) {
      console.error("Error saving personel", error);
    }
  };

  return (
    <div className="container">
      <div className="card">
        <div className="card-body">
          <h2 className="card-title text-center">
            {id ? "Personel Güncelle" : "Personel Ekle"}
          </h2>
          <form onSubmit={handleSubmit}>
            <div className="form-group mb-3">
              <label>Adı:</label>
              <input
                type="text"
                name="firstName"
                className="form-control"
                value={formData.firstName}
                onChange={handleChange}
                required
              />
            </div>
            <div className="form-group mb-3">
              <label>Soyadı:</label>
              <input
                type="text"
                name="lastName"
                className="form-control"
                value={formData.lastName}
                onChange={handleChange}
                required
              />
            </div>
            <div className="form-group mb-3">
              <label>Cinsiyet:</label>
              <div className="d-flex">
                <div className="form-check me-3">
                  <input
                    type="radio"
                    name="gender"
                    value="Erkek"
                    className="form-check-input"
                    checked={formData.gender === "Erkek"}
                    onChange={handleChange}
                  />
                  <label className="form-check-label">Erkek</label>
                </div>
                <div className="form-check">
                  <input
                    type="radio"
                    name="gender"
                    value="Kadın"
                    className="form-check-input"
                    checked={formData.gender === "Kadın"}
                    onChange={handleChange}
                  />
                  <label className="form-check-label">Kadın</label>
                </div>
              </div>
            </div>
            <div className="form-group mb-3">
              <label>Zimmetler:</label>
              <Select
                isMulti
                value={formData.debits.map((debit) => ({
                  label: debit.name,
                  value: debit.name,
                }))}
                onChange={handleSelectChange}
                options={debitOptions}
                placeholder="Zimmet seçiniz"
              />
            </div>
            <div className="form-group mb-3">
              <label>Üniversite:</label>
              <Select
                value={
                  formData.university
                    ? { value: formData.university, label: formData.university }
                    : null
                }
                onChange={handleUniversityChange}
                options={universities}
                placeholder="Üniversite seçiniz"
                required
              />
            </div>
            <div className="text-center mt-4">
              <button type="submit" className="btn btn-success me-2 btn-lg">
                Kaydet
              </button>
              <button
                type="button"
                className="btn btn-secondary"
                onClick={() => navigate("/")}
              >
                İptal
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default PersonelForm;
