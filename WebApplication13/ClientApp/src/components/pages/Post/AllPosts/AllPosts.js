import React, { Component } from 'react';

export class AllPosts extends Component {
    static displayName = AllPosts.name;

  constructor(props) {
    super(props);
    this.state = { posts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }


  


  static renderForecastsTable(posts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>        
            <th>Title</th>
            <th>Details</th>
          </tr>
        </thead>
        <tbody>
                {posts.map(post =>
                    <tr key={post.id}>
                        <td> <a href={"/one-post/" + post.urlSlug}> {post.title} </a> </td>
                        <td> <a href={"/one-post/" + post.urlSlug} class="btn btn-primary">details </a></td>
                    </tr>
                 )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : AllPosts.renderForecastsTable(this.state.posts);

    return (
      <div>
        <h1 id="tabelLabel" >Our posts</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

    async populateWeatherData() {                            //методзапроса на сервер                                  
        const response = await fetch('post');         //асинхронный запрос - по маршруту: post - тип запроса GET
        const data = await response.json();                          //ответ конвертим в json   
        this.setState({ posts: data, loading: false });          //меняем состояние обьекта state - инитим forecasts массив данными с сервера
    }
}
