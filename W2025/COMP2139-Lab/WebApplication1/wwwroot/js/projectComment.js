function loadComments(projectId){
    $.ajax({
        method:"GET",
        url:'/ProjectManagement/ProjectComment/GetComments?projectId='+projectId,
        success:function(data){
            var commentsHtml = '';
            for(var i=0;i<data.length;i++){
                commentsHtml+='<div class="comment">';
                commentsHtml+='<p>'+data[i].Content+'</p>';
                commentsHtml+='<span>Posted On:' + new Date(data[i].DatePosted).toLocaleDateString()+'</span>';
                commentsHtml+='</div>';
            }
            $('#commentList').html(commentsHtml);
        }
    })
    
   
}

$(document).ready(function (){
    var projectId = $('#projectComments input[name="ProjectId"]').val()
    loadComments(projectId);
    
    $('#addCommentForm').submit(function (evt){
        evt.preventDefault();
        var fromData={
            projectId:projectId,
            Content:$('#projectComments input[name="Content"]').val()
        }
        $.ajax({
            method:"GET",
            url:'/ProjectManagement/ProjectComment/AddComment',
            contentType:'application/json',
            data:JSON.stringify(fromData),
            
            success:function(data){
                if(response.success){
                    $('#projectComments textarea[name="Comment"]').val('');
                }else {
                    alert(response.message);
                }
            },
            error:function(xhr,status,error){
              alert("error"+xhr.responseText);  
            }
        })
    })
})