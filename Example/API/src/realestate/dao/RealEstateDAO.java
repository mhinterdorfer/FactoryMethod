package realestate.dao;

import java.util.List;

import javax.inject.Named;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import realestate.model.RealEstateModel;

@Named
public class RealEstateDAO {
    @PersistenceContext
    EntityManager em;

    public List<RealEstateModel> findAll() {
	return em.createQuery("select r from RealEstateModel r", RealEstateModel.class).getResultList();
    }

    public RealEstateModel findById(int id) {
	return em.find(RealEstateModel.class, id);
    }

    public void deleteById(int id) {
	RealEstateModel re = findById(id);
	em.remove(re);
    }

    public void saveOrUpdate(RealEstateModel re) {
	em.merge(re);
    }
}