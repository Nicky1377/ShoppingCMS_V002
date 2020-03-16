$("#loginButton").on('click', function(e)
{
    e.preventDefault();
    $('.login').addClass('test')	
    setTimeout(function(){	
        $('.login').addClass('testtwo')	
    },300);	
    setTimeout(function(){	
        $(".authent").show().animate({right:-320},{easing : 'easeOutQuint' ,duration: 600, queue: false });	
        $(".authent").animate({opacity: 1},{duration: 200, queue: false }).addClass('visible');	
    },350);	
    
    setTimeout(function(){	
        $(".authent").show().animate({right:90},{easing : 'easeOutQuint' ,duration: 600, queue: false });	
        $(".authent").animate({ opacity: 1 }, { duration: 200, queue: false }).addClass('visible');	
        $('#Authenn').attr("style","display:none!important");

        $('.login').removeClass('testtwo')	
    },2500);	
    setTimeout(function(){	
        $('.login').removeClass('test')	
        $('.login div').fadeOut(123);	
    },2800);	
    setTimeout(function(){	
        $('.success').fadeIn();	
        
    },3200);
    
    setTimeout(function()
    {
        $('.success').fadeOut(123);
        $('.login div').fadeIn(123);
        $('#error').fadeOut();
        
    }, 10000);
});+`+`


$('#usernametxt,#passwordtxt').focus(function(){	
    $(this).prev().animate({'opacity':'1'},200)	
});	
$('#usernametxt,#passwordtxt').blur(function(){	
    $(this).prev().animate({'opacity':'.5'},200)	
});	
$('#usernametxt,#passwordtxt').keyup(function(){	
    if(!$(this).val() == ''){	
        $(this).next().animate({'opacity':'1','right' : '30'},200)	
    } else {	
        $(this).next().animate({'opacity':'0','right' : '20'},200)	
    }	
});