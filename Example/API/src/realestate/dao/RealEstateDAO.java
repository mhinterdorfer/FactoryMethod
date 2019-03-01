package realestate.dao;

import java.util.List;

import javax.inject.Named;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import realestate.model.RealEstate;

@Named
public class RealEstateDAO {
    @PersistenceContext
    EntityManager em;

    public List<RealEstate> findAll() {
	return em.createQuery("SELECT r FROM RealEstate r", RealEstate.class).getResultList();
    }

    public RealEstate findById(int id) {
	return em.find(RealEstate.class, id);
    }

    public void deleteById(int id) {
	RealEstate re = findById(id);
	em.remove(re);
    }

    public void saveOrUpdate(RealEstate re) {
	em.merge(re);
    }
}