package realestate.rest;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.enterprise.context.RequestScoped;
import javax.inject.Inject;
import javax.transaction.Transactional;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.OPTIONS;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.ResponseBuilder;
import javax.ws.rs.core.Response.Status;

import javax.ws.rs.core.UriBuilder;

import realestate.dao.RealEstateDAO;
import realestate.interfaces.Location;
import realestate.interfaces.RealEstate;
import realestate.interfaces.RealEstateFactory;
import realestate.interfaces.RealEstateType;
import realestate.model.RealEstateModel;

@RequestScoped
@Path("/realestates")
@Produces("application/json")
@Consumes("application/json")
public class RealEstateEndpoint {
    @Inject
    RealEstateDAO dao;

    @POST
    @Transactional
    public Response create(final RealEstateModel realestate) {
	RealEstateModel new_re = new RealEstateModel();
	new_re.setGardenSquaremeter(realestate.getGardenSquaremeter());
	new_re.setLocation(realestate.getLocation());
	new_re.setNumOfParkinglots(realestate.getNumOfParkinglots());
	new_re.setRooms(realestate.getRooms());
	new_re.setSquaremeter(realestate.getSquaremeter());
	new_re.setType(realestate.getType());
	dao.saveOrUpdate(new_re);
	return Response.created(
		UriBuilder.fromResource(RealEstateEndpoint.class).path(String.valueOf(new_re.getIdRealEsate())).build())
		.build();
    }

    @GET
    @Path("/{id:[0-9][0-9]*}")
    @Transactional
    public Response findById(@PathParam("id") final int id) {
	RealEstateModel realestate = dao.findById(id);
	if (realestate == null) {
	    return Response.status(Status.NOT_FOUND).build();
	}
	return Response.ok(realestate).build();
    }

    @GET
    @Transactional
    public Response listAll(@QueryParam("start") final Integer startPosition,
	    @QueryParam("max") final Integer maxResult) {
	List<RealEstateModel> realestatemodels = dao.findAll();
	return (Response) Response.ok()
		.header("Access-Control-Allow-Origin", "*")
                .header("Access-Control-Allow-Headers", "origin, content-type, accept, authorization")
                .header("Access-Control-Allow-Credentials", "true")
                .header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, HEAD")
		.entity(realestatemodels).build();
    }

    @PUT
    @Path("/{id:[0-9][0-9]*}")
    @Transactional
    public Response update(@PathParam("id") int id, final RealEstateModel realestate) {
	RealEstateModel new_re = dao.findById(id);
	new_re.setGardenSquaremeter(realestate.getGardenSquaremeter());
	new_re.setLocation(realestate.getLocation());
	new_re.setNumOfParkinglots(realestate.getNumOfParkinglots());
	new_re.setRooms(realestate.getRooms());
	new_re.setSquaremeter(realestate.getSquaremeter());
	new_re.setType(realestate.getType());
	dao.saveOrUpdate(new_re);
	return Response.noContent().build();
    }

    @DELETE
    @Path("/{id:[0-9][0-9]*}")
    @Transactional
    public Response deleteById(@PathParam("id") final int id) {
	dao.deleteById(id);
	return Response.noContent().build();
    }
    
    @OPTIONS
    @Path("{path : .*}")
    public Response options() {
        return Response.ok("")
                .header("Access-Control-Allow-Origin", "*")
                .header("Access-Control-Allow-Headers", "origin, content-type, accept, authorization")
                .header("Access-Control-Allow-Credentials", "true")
                .header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, HEAD")
                .header("Access-Control-Max-Age", "1209600")
                .build();
    }

}
