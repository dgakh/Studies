/*******************************************************************************
 * Copyright (c) 2015 Dmitriy Gakh ( dmgakh@gmail.com ).
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 ******************************************************************************/

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class SrvltCalculator
 */
@WebServlet("/SrvltCalculator")
public class SrvltCalculator extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		String str_a = request.getParameter("a");
		String str_b = request.getParameter("b");
		String str_op = request.getParameter("op");		
		
		double value_a = 0;
		double value_b = 0;
		
		boolean noError = true;
		
		try {
			value_a = Double.parseDouble(str_a);
			value_b = Double.parseDouble(str_b);
		}
		catch ( Exception ex ) {
			noError = false;
		}
		
		if ( noError ) {
			
			double result = 0;
			
			try {
				
				if (str_op.endsWith("+")) result = functionSum( value_a, value_b );
				else
					if (str_op.endsWith("-")) result = functionDif( value_a, value_b );
					else
						if (str_op.endsWith("*")) result = functionMul( value_a, value_b );
						else
							if (str_op.endsWith("/") && (value_b!=0)) result = functionDiv( value_a, value_b );
							else
								noError = false;
			}
			catch ( Exception ex ) {
				noError = false;
			}
			
			if ( noError ) {
				doSetResult( response, result );
				return;
			}
			
		}
		
		doSetError( response );
	}
	
	protected void doSetResult( HttpServletResponse response, double result ) throws UnsupportedEncodingException, IOException {
		String reply = "{\"error\":0,\"result\":" + Double.toString(result) + "}";
		response.getOutputStream().write( reply.getBytes("UTF-8") );
		response.setContentType("application/json; charset=UTF-8");
		response.setStatus( HttpServletResponse.SC_OK );
	}		
	
	protected void doSetError( HttpServletResponse response ) throws UnsupportedEncodingException, IOException {
		String reply = "{\"error\":1}";
		response.getOutputStream().write( reply.getBytes("UTF-8") );
		response.setContentType("application/json; charset=UTF-8");
		response.setStatus( HttpServletResponse.SC_OK );
	}
	
	protected double functionSum( double a, double b ) {
		return a + b;
	}
	
	protected double functionDif( double a, double b ) {
		return a - b;
	}
	
	protected double functionMul( double a, double b ) {
		return a * b;
	}
	
	protected double functionDiv( double a, double b ) {
		return a / b;
	}
	
}
