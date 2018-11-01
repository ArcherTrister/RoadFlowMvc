(function($){
	var bigColorPicker = new function(){
		this.sideLength = 6;//���������ÿ���߳�
		this.targetEl = {};
		var allColorArray = [];//������ɫ�����Ϊǰ���У����������з�Ϊ6���飬����������������������һ���ܵĶ�ά������
		var sideLength = 6;
		this.init = function(){
			sideLength = this.sideLength;
			allColorArray = new Array(sideLength*3);
			//�����һ�е�����
			var mixColorArray = [];
			var blackWhiteGradientArray = gradientColor(new RGB(0,0,0),new RGB(255,255,255));
			for(var i=0;i<blackWhiteGradientArray.length;i++){
				mixColorArray[i] = blackWhiteGradientArray[i];
			}
			var baseArray = [new RGB(255,0,0),new RGB(0,255,0),new RGB(0,0,255),new RGB(255,255,0),new RGB(0,255,255),new RGB(255,0,255),new RGB(204,255,0),new RGB(153,0,255),new RGB(102,255,255),new RGB(51,0,0)];
			mixColorArray = mixColorArray.concat(baseArray.slice(0, sideLength))
			allColorArray[0] = mixColorArray;
			
			//����ڶ��е�����
			var blackArray = new Array(sideLength*2);
			for(var i=0;i<blackArray.length;i++){
				blackArray[i] = new RGB(0,0,0);
			}
			allColorArray[1] = blackArray;
			
			//�����������������
			var cornerColorArray = new Array();//����Ԫ�أ�ÿ��Ԫ�ط�6��������Ľ���ɫ��ά����
			cornerColorArray.push(generateBlockcornerColor(0),generateBlockcornerColor(51),generateBlockcornerColor(102),generateBlockcornerColor(153),generateBlockcornerColor(204),generateBlockcornerColor(255));
			var count = 0;
			var halfOfAllArray1 = [];
			var halfOfAllArray2 = [];
			for(var i=0;i<cornerColorArray.length;i++){
				var startArray = gradientColor(cornerColorArray[i][0][0],cornerColorArray[i][0][1])
				var endArray = gradientColor(cornerColorArray[i][1][0],cornerColorArray[i][1][1])
				for(var j=0;j<sideLength;j++){
					if(i < 3){
						halfOfAllArray1[count] = gradientColor(startArray[j],endArray[j]);
					}else{
						halfOfAllArray2[count - sideLength*3] = gradientColor(startArray[j],endArray[j]);
						
					}
					count++;
				}
			}
			for(var i=0;i<halfOfAllArray1.length;i++){
				allColorArray[i + 2] = halfOfAllArray1[i].concat(halfOfAllArray2[i]);
			}
			
			//�����������е�RGB��ɫת����Hex��ʽ
			for(var i=0;i<allColorArray.length;i++){
				for(var j=0;j<allColorArray[i].length;j++){
					allColorArray[i][j] = RGBToHex(allColorArray[i][j]);
				}
			}
		}
		/*
		 * callback:������undefined����������ʱ�����ַ���������
		 * 		undefined����ѡ�����ɫ���õ���bigColorpicker��Ԫ�ص�value�ϡ�
		 * 		�ַ�������ѡ�����ɫ���õ�idΪ"�ַ���"��Ԫ�ص�value�ϡ�
		 * 		������ִ�д���ĺ�����ʵ���Զ���Ļ�ȡ��ɫ��Ķ�����
		 * engine:������undefined��p(��P)��l(��L)��
		 * 		��bigColorpickerչ����ɫѡ������С��ʱ������ʵ�ַ�ʽ��
		 *     һ����һ�ű���ͼƬ�����ù�궨λ�ķ�ʽ��ȡ��ɫ��p(��P)
		 *     ����ÿ��С�����һ��li������li�ı�����ɫ��l(��L)
		 *     ʵ�ַ�ʽ�Ĳ�ͬ��Ч���������죬�����Լ���ʹ��ʱѡ��Ĭ����p(��P)��
		 *     undefined����������ʱ����ʹ��Ĭ��p(��P)
		 * sideLength:������ɫ����Ĵ�Сȡֵ��ΧΪ2��10��Ĭ��Ϊ6,ֻ��engineΪLʱ����Ч
		 */
		this.showPicker = function(callback,engine,sideLength_){
			var sl_ = parseInt(sideLength_,10);
			if(engine == "L" && !isNaN(sl_) && sl_ >=2 && sl_ <= 10){
				bigColorPicker.sideLength = sl_;
			}else{
				bigColorPicker.sideLength = 6;
			}
			bigColorPicker.init();
			bigColorPicker.targetEl = this;
			$(bigColorPicker.targetEl).data("bigpickerCallback",callback);
			$(bigColorPicker.targetEl).data("bigpickerId","bigpicker");
			
			if($("#bigpicker").length <=0){
				$(document.body).append('<div id="bigpicker" class="bigpicker"><ul class="bigpicker-bgview-text" ><li><div id="bigBgshowDiv"></div></li><li><input id="bigHexColorText" size="7" maxlength="7" value="#000000" /></li></ul><div id="bigSections" class="bigpicker-sections-color"></div><div id="bigLayout" class="biglayout" >&nbsp;</div></div>');
				
			}
			$("#bigLayout").unbind("hover").unbind("click").hover(function(){
				$(this).show();
			},function(){
				$(this).hide();
			}).click(function(){
				$("#bigpicker").hide();
			});
			
			//��ɫʰȡ��text�����ע���¼�
			$("#bigHexColorText").unbind("keypress").unbind("keyup").unbind("focus").keypress(function(){
				var text = $.trim($(this).val());
				$(this).val(text.replace(/[^A-Fa-f0-9#]/g,''));
				if(text.length <= 0)return;
				text = text.charAt(0)=='#'?text:"#" + text;
				var countChar = 7 - text.length;
				if(countChar < 0){
					text = text.substring(0,7);
				}else if(countChar > 0){
					for(var i=0;i<countChar;i++){
						text += "0";
					};
				}
				$("#bigBgshowDiv").css("backgroundColor",text);
			}).keyup(function(){
				var text = $.trim($(this).val());
				$(this).val(text.replace(/[^A-Fa-f0-9#]/g,''));	
			}).focus(function(){
				this.select();
			})		
			
			
			//�������ʰȡ��ɫ��Ԫ�ذ�click�¼�����ʾ��ɫʰȡ��
			$(this).unbind("click").bind("click",bigpickerShow);
			function bigpickerShow(event){
				bigColorPicker.targetEl = event.currentTarget;
				var $this = $(bigColorPicker.targetEl);
				$("#bigBgshowDiv").css("backgroundColor","#000000");
				$("#bigHexColorText").val("#000000");
				
				var pos = calculatePosition ($this);
				$("#bigpicker").css({"left":pos.left + "px","top":pos.top + "px"}).fadeIn(300);
				
				var bigSectionsP = $("#bigSections").position();
				$("#bigLayout").css({"left":bigSectionsP.left,"top":bigSectionsP.top}).show();
				
				$(document).bind('mousedown',bigpickerHide);
			}
			
			if(engine != undefined){
				try{
					engine = engine.toUpperCase();
				}catch(e){
					engine = "P";
				}
			}
			
			if(engine == "L" ){
				$("#bigSections").unbind("mousemove").unbind("mouseout").unbind("click").removeClass("bigpicker-bgimage");;
				generateBgImage();
			}else{
				//Ԥ����ͼƬ
			     var bgmage = new Image();
			     //bgmage.src = "../images/big_bgcolor.jpg";
			     
			     //��ʼ��ΪĬ����ʽ
				$("#bigSections").height(134).width(223).addClass("bigpicker-bgimage").empty();
				$("#bigpicker").width(227).height(163);
				//����ƶ�ʱ�����������
				var xSections = getSections(sideLength*3 + 2);
				var ySections = getSections(sideLength*3);
				$("#bigSections").unbind("mousemove").unbind("mouseout").unbind("click").mousemove(function(event){
					var $this = $(this);
					var cursorXPos = event.pageX - $this.offset().left;
					var cursorYPos = event.pageY - $this.offset().top;
					var xi = 0;
					var yi = 0;
					for(var i=0;i<(sideLength*3+2);i++){
						if(cursorXPos >= xSections[i][0] && cursorXPos <= xSections[i][1]){
							xi = i;
							break;
						}
					}
					for(var i=0;i<(sideLength*3);i++){
						if(cursorYPos >= ySections[i][0] && cursorYPos <= ySections[i][1]){
							yi = i;
							break;
						}
					}
					$("#bigLayout").css({"left":$this.position().left + xi*11,"top":$this.position().top + yi*11}).show();
					var hex = allColorArray[xi][yi];
					$("#bigBgshowDiv").css("backgroundColor",hex);
					$("#bigHexColorText").val(hex);
					
					invokeCallBack(hex);
					
				}).mouseout(function(){
					$("#bigLayout").hide();
				});
			}
			
			/*
			*/
		}
		
		this.hidePicker = function(){
			var id = $(bigColorPicker.targetEl).data("bigpickerId");
			$("#" + id).hide();
			$(document).unbind('mousedown');			
		}
		
		this.movePicker = function(){
			var $this = $(bigColorPicker.targetEl);
			var pos = calculatePosition ($this);
			$("#bigpicker").css({"left":pos.left + "px","top":pos.top + "px"});
			$("#bigLayout").hide();
		}
		
		function bigpickerHide(event){
			var cursorX = event.pageX;
			var cursorY = event.pageY;			
			var $bigpicker = $("#bigpicker");
			var p = $bigpicker.offset();
			var flag = true;//��ʶ����Ƿ�����ɫʰȡ����
			if(cursorX < p.left || cursorX > p.left + $bigpicker.width() || cursorY < p.top || cursorY >p.top + $bigpicker.height()){
				flag = false;
			}
			if(!flag){
				$("#bigpicker").hide();
				$(document).unbind('mousedown');
			}
		}
		//�����ʰȡ�����left,top����
		function calculatePosition ($el) {
			var offset = $el.offset();
			var compatMode = document.compatMode == 'CSS1Compat';
			var w = compatMode ? document.documentElement.clientWidth : document.body.clientWidth;
			var h = compatMode ? document.documentElement.clientHeight : document.body.clientHeight;
			var pos = {left:offset.left,top:offset.top + $el.height() + 7};
			if(offset.left + 227 > w){
				pos.left = offset.left - 227 - 7;
				if(pos.left < 0){
					pos.left = 0;
				}						
			}
			if(offset.top + $el.height() + 7 + 163 > h){
				pos.top = offset.top - 163 - 7;
				if(pos.top < 0){
					pos.top = 0;
				}
			}
			return pos;
		}		
		
		function invokeCallBack(hex){
			var callback_ = $(bigColorPicker.targetEl).data("bigpickerCallback");
			if($.isFunction(callback_)){
				callback_(bigColorPicker.targetEl,hex);
			}else if(callback_ == undefined || callback_ == ""){
				$(bigColorPicker.targetEl).val(hex);
			}else{
				if(callback_.charAt(0) != "#"){
					callback_ = "#" + callback_;
				}
				$(callback_).val(hex);
			}			
		}
		
		//����С������ĸ��ǵ���ɫ��ά����
		function generateBlockcornerColor(r){
			var a = new Array(2);
			a[0] = [new RGB(r,0,0),new RGB(r,255,0)];
			a[1] = [new RGB(r,0,255),new RGB(r,255,255)];			
			return a;
		}

		//������ɫ�Ľ�����ɫ����
		function gradientColor(startColor,endColor){
			var gradientArray = [];
			gradientArray[0] = startColor;
			gradientArray[sideLength-1] = endColor;
			var averageR = Math.round((endColor.r - startColor.r)/sideLength);
			var averageG = Math.round((endColor.g - startColor.g)/sideLength);
			var averageB = Math.round((endColor.b - startColor.b)/sideLength);
			for(var i=1;i<sideLength-1;i++){
				gradientArray[i] =  new RGB(startColor.r + i*averageR,startColor.g + i*averageG,startColor.b + i*averageB);
			}			
			return gradientArray;
		}
		/*��ȡһ����ά�����������[0,11],[12,23],[24,37]..
		 * sl:����ĳ���
		*/
		function getSections(sl){
			var sections = new Array(sl);
			var initData = 0; 
			for(var i=0;i<sl;i++){
				var temp = initData + 1;
				initData += 11;
				sections[i] = [temp,initData];
			}			
			return sections;
		}
		
		function RGBToHex(rgb){
			var hex = "#";
			for(c in rgb){
				var h = rgb[c].toString(16).toUpperCase();
				if(h.length == 1){
					hex += "0" + h;
				}else{
					hex += h;
				}
			}
			return hex;
		}
		
		//RGB�����������ڴ���һ��RGB��ɫ����
		function RGB(r,g,b){
			this.r = Math.max(Math.min(r,255),0);
			this.g = Math.max(Math.min(g,255),0);
			this.b = Math.max(Math.min(b,255),0);
		}
		
		
		//���ɱ�����ɫ
		function generateBgImage(){
			var ulArray = new Array();
			var widthLength = sideLength*3 + 2;//��ɫ���������ɫ����
			var heigthLength = sideLength*2; //��ɫ���������ɫ����
			for(var i=0;i<widthLength;i++){
				ulArray.push("<ul>");
				for(var j=0;j<heigthLength;j++){
					var borderBottom = "" ;
					var borderRight = "" ;
					if(i == widthLength -1){
						borderRight = "border-right:solid 1px #000000;" ;
					}
					if(j == heigthLength -1){
						borderBottom = "border-bottom:solid 1px #000000;" ;
					}
					ulArray.push("<li data-color='" + allColorArray[i][j] + "' style='" + borderRight + borderBottom + "background-color: " + allColorArray[i][j] + ";' >&nbsp;</li>");
				}
				ulArray.push("</ul>");
			}
			$("#bigSections").html(ulArray.join(""));
			var minBigpickerHeight = 90;
			var minBigpickerWidth = 129;
			var minSectionsWidth = minBigpickerWidth - 5;
			var minSectionsHeight = minBigpickerHeight - 29;
			var defaultSectionsWidth = widthLength*11;
			
			if(defaultSectionsWidth < minSectionsWidth){
				$("#bigSections li,#bigLayout").width(minSectionsWidth/(widthLength) - 1).height(minSectionsHeight/(heigthLength) - 1);
				$("#bigpicker").height(minBigpickerHeight).width(minBigpickerWidth);
			}else{
				$("#bigpicker").width(defaultSectionsWidth + 5)
				               .height(heigthLength*11 + 29);
				
			}			
			$("#bigSections li").hover(function(){
				var $this = $(this);
				$("#bigLayout").css({"left":$this.position().left,"top":$this.position().top}).show();
				
				var cor = $this.attr("data-color");
				$("#bigBgshowDiv").css("backgroundColor",cor);
				$("#bigHexColorText").val(cor);
				invokeCallBack(cor);				
			},function(){
				$("#bigLayout").hide();
			});
		}
		
	};
	
	$.fn.bigColorpicker = bigColorPicker.showPicker;
	$.fn.bigColorpickerMove = bigColorPicker.movePicker; //ʹ������ק�ĸ����ϣ�����קʱʰȡ���渡���ƶ�λ��
	$.fn.bigColorpickerHide = bigColorPicker.hidePicker; //��ӦһЩ�ض���Ӧ����Ҫ�ֶ�����ʰȡ��ʱʹ�á�������ק����ʱ����ʰȡ��
})(jQuery)