import React, { Component } from 'react';
import './OnePost.css';


export class OnePost extends Component {
    static displayName = OnePost.name;

  constructor(props) {
    super(props);
    this.state = { post: null, loading: true };
  }

  componentDidMount() {
    this.populateData();
  }

    static renderForecastsTable(post) {

       
    /*    console.log("Пост", post);*/
      return (

          <div>
              
               {/* <!-- Page Banner -->*/}
              <div className="container-fluid no-padding page-banner">
                  {/*<!-- Container -->*/}
                  <div className="container">
                     {/* <!-- Banner Heading -->*/}
                      <div className="banner-heading">
                          <h3>{post.title}</h3>
                          <h5 className="onePost-Id hidden">{post.id}</h5>
                          <ol className="breadcrumb">
                              <li><a href="/">Главная</a></li>
                              <li><a href="/Post/index">Все Посты</a></li>
                              <li className="active">Просмотр поста</li>
                          </ol>
                      </div> {/*<!-- Banner Heading /- -->*/}
                  </div> {/*<!-- Container /- -->*/}
              </div>
                {/*<!--Page Banner / - -->*/}



                    {/*<!--Blog List-- >*/}
                <div className="container-fluid no-padding blog-list">
                    <div className="section-padding"></div>
                    {/*<!-- Container -->*/}
                    <div className="container">
                        <div className="row">
                            {/*<!-- Blog Area -->*/}
                            <div className="col-md-9 col-sm-9 col-xs-12 blog-area single-post">
                                <div className="section-title">
                                  <h3>{post.title}</h3>
                                  <p>{post.slogan}</p>
                                </div>
                              <article>
                                  <div className="entry-cover">
                                      <img src={post.imgSrc} alt={post.imgAlt} />
                                  </div>
                                
                                  <div className="post-content">
                                      <div className="post-meta">
                                          <div className="post-date">
                                              <span> {post.dateOfPublished} </span>
                                              <span>{post.dateOfPublished}  </span>
                                          </div>
                                          <div className="post-comment">
                                              <i><img src="~/images/icon/comment.png" alt="Comment" /></i>
                                              <a href="#">17</a>
                                          </div>
                                          <div className="post-share pull-right">
                                              <a href="#"><i className="fa fa-reply"></i>Reply</a>
                                              <a href="#"><i><img src="~/images/icon/share.png" alt="Comment" /></i>Share</a>
                                          </div>
                                      </div>
                                      <h3 className="entry-title">{post.slogan}</h3>
                                      <div className="entry-content">
                                          {post.content} 
                                      </div>
                                      <div className="entry-footer">
                                          <div className="post-admin">
                                              <i><img src="~/images/icon/admin-ic.png" alt="admin-ic" /></i>Posted by<a href="#">Admin</a>
                                          </div>
                                          <div className="tags">
                                              <i><img src="~/images/icon/tags.png" alt="Tags" /></i>
                                              <a href="#">Pets</a>
                                              <a href="#">Veterinary</a>
                                              <a href="#">Dog</a>
                                              <a href="#">Ear</a>
                                              <a href="#">Cleaning</a>
                                              <a href="#">Doctor</a>
                                          </div>
                                      </div>
                                  </div>
                              </article>



                            </div>
                        </div>
                    </div>
                </div>


          </div>
                             

    );
  }

    render() {
        let contents = <p><em> </em></p>;
        if (this.state.loading) {
            contents = <p><em>Loading...</em></p>;
        }else if (this.state.post == null) {
            contents = <p><em>no post found </em></p>; 
        } else {
            contents = OnePost.renderForecastsTable(this.state.post);
        }


        //let contents = this.state.loading
        //  ? <p><em>Loading...</em></p>
        //    : OnePost.renderForecastsTable(this.state.post);
        return (
            <div>
            <h2>{this.props.match.params.id}</h2>
            <h1>One post </h1>        
            {contents}
          </div>
        );
  }

    async populateData() {                                   //методзапроса на сервер 
        const encodedValue = encodeURIComponent(this.props.match.params.id);
       
        const response = await fetch(`post/${encodedValue}`);// const response = await fetch('post');                   //асинхронный запрос - по маршруту: employee - тип запроса GET
        if (response.status === 200) {
            const data = await response.json(); //ответ конвертим в json
            this.setState({ post: data, loading: false }); //меняем состояние обьекта state - инитим forecasts массив данными с сервера
        } else if (response.status === 204) {
            this.setState({ post: null, loading: false });
        } else {
            // Other problem!
        }
       
        
      
    }
}
