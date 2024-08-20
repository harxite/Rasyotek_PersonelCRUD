import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getPersonellers, deletePersonel } from "../services/personelService";

const PersonelList = () => {
  const [personellers, setPersonellers] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    fetchPersonellers();
  }, []);

  const fetchPersonellers = async () => {
    try {
      const response = await getPersonellers();
      setPersonellers(response.data);
    } catch (error) {
      console.error("Error fetching personellers", error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await deletePersonel(id);
      fetchPersonellers();
    } catch (error) {
      console.error("Error deleting personel", error);
    }
  };

  const handleEdit = (id) => {
    navigate(`/edit/${id}`);
  };

  return (
    <div className="container">
      <h2 className="text-center mb-4">Personel Listesi</h2>
      <div className="text-center mb-4">
        <button className="btn btn-primary" onClick={() => navigate("/add")}>
          Personel Ekle
        </button>
      </div>
      <div className="table-responsive">
        <table className="table table-bordered table-striped">
          <thead className="thead-dark">
            <tr>
              <th>Ad</th>
              <th>Soyad</th>
              <th>Cinsiyet</th>
              <th>Zimmetler</th>
              <th>Üniversite</th>
              <th>İşlem</th>
            </tr>
          </thead>
          <tbody>
            {personellers.map((personel) => (
              <tr key={personel.id}>
                <td>{personel.firstName}</td>
                <td>{personel.lastName}</td>
                <td>{personel.gender}</td>
                <td>
                  {personel.debits && personel.debits.length > 0
                    ? personel.debits.map((debit) => debit.name).join(", ")
                    : "Yok"}
                </td>
                <td>{personel.university}</td>
                <td>
                  <button
                    className="btn btn-warning me-2"
                    onClick={() => handleEdit(personel.id)}
                  >
                    Güncelle
                  </button>
                  <button
                    className="btn btn-danger"
                    onClick={() => handleDelete(personel.id)}
                  >
                    Sil
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default PersonelList;
