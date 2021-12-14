import React, { Component } from 'react';
import Pagination from './Pagination';
import Countries from 'countries-api';
import CountryCard from './CountryCard';


export class AllPosts extends Component {

    state = { totalCount: 7, currentCountries: [], currentPage: 1, totalPages: null }  //   spike

    componentDidMount() {     

        fetch(`post/all?page=1`)
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                console.log(data);
                const currentCountries = data.posts;
                const totalCount = data.totalCount;
                
                const currentPage = 1;
                const pageLimit = 3;
                const totalPages = Math.ceil(totalCount / pageLimit);
             
                this.setState({ totalCount, currentPage, currentCountries, totalPages });
            });
    }



    onPageChanged = data => {
       
        const { currentPage, totalPages, pageLimit } = data;
        // https://localhost:44394/post/all?page=1  
      
        fetch(`post/all?page=${currentPage}`)
            .then((response) => {
                return response.json();
            })
            .then((data) => {
                console.log(data);
                const currentCountries = data.posts;
                const totalCount = data.totalCount;              
                const pageLimit = 3;
                const totalPages = Math.ceil(totalCount / pageLimit);
                this.setState({ totalCount, currentPage, currentCountries, totalPages });
            });

      

    }

    render() {
        const { totalCount, currentCountries, currentPage, totalPages } = this.state;
       
        if (totalCount === 0) return (
           <div className="container mb-5">
                
                <h1> Not found </h1>
               
            </div>
        );

        const headerClass = ['text-dark py-2 pr-4 m-0', currentPage ? 'border-gray border-right' : ''].join(' ').trim();

        return (
            <div className="container mb-5">
                <div className="row d-flex flex-row py-5">

                    <div className="w-100 px-4 py-5 d-flex flex-row flex-wrap align-items-center justify-content-between">
                        <div className="d-flex flex-row align-items-center">

                            <h2 className={headerClass}>
                                <strong className="text-secondary">{totalCount}</strong> Countries
                            </h2>

                            {currentPage && (
                                <span className="current-page d-inline-block h-100 pl-4 text-secondary">
                                    Page <span className="font-weight-bold">{currentPage}</span> / <span className="font-weight-bold">{totalPages}</span>
                                </span>
                            )}

                        </div>

                        <div className="d-flex flex-row py-4 align-items-center">
                            <Pagination totalRecords={totalCount} pageLimit={3} pageNeighbours={1} onPageChanged={this.onPageChanged} />
                        </div>
                    </div>

                  

                    {currentCountries.map(country =>
                        <p>
                            <a href={"/one-post/" + country.urlSlug}> {country.title} </a>  <br />
                        </p>)}

                </div>
            </div>
        );
    }

}

export default AllPosts;




























  //constructor(props) {
  //  super(props);
  //  this.state = { posts: [], loading: true };
  //}



  //static renderForecastsTable(posts) {
  //    return (
  //        <div>
  //            <table className='table table-striped' aria-labelledby="tabelLabel">
  //                <thead>
  //                    <tr>
  //                        <th>Title</th>
  //                        <th>Details</th>
  //                    </tr>
  //                </thead>
  //                <tbody>
  //                    {posts.map(post =>
  //                        <tr key={post.id}>
  //                            <td> <a href={"/one-post/" + post.urlSlug}> {post.title} </a> </td>
  //                            <td> <a href={"/one-post/" + post.urlSlug} class="btn btn-primary">details </a></td>
  //                        </tr>
  //                    )}
  //                </tbody>
  //            </table>

  //            {[...Array(10)].map((x, i) =>                
  //                <a href={`all-posts/${i+1}`} class="btn btn-primary">{ i+1 } </a>
  //            )}

  //        </div>
  //  );
  //}

  //render() {
  //  let contents = this.state.loading
  //    ? <p><em>Loading...</em></p>
  //      : AllPosts.renderForecastsTable(this.state.posts);

  //  return (
  //    <div>
  //      <h1 id="tabelLabel" >Our posts</h1>
  //      <p>This component demonstrates fetching data from the server.</p>
  //      {contents}
  //    </div>
  //  );
  //}






